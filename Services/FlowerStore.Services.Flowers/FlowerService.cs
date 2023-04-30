using FlowerStore.Context;
using FlowerStore.Context.Entities;
using FlowerStore.Services.Flowers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerStore.Common.Exceptions;
using FlowerStore.Services.UserAccount;
using FlowersStore.Services;
using ObjectMapper;

namespace FlowerStore.Services.Flowers
{
    public class FlowerService : IFlowerService
    {
        private readonly MainDbContext context;
        private readonly IUserAccountService userAccountService;
        private readonly ICategoryService categoryService;

        public FlowerService(MainDbContext context,
                             IUserAccountService userAccountService,
                             ICategoryService categoryService)
        {
            this.context = context;
            this.userAccountService = userAccountService;
            this.categoryService = categoryService;
        }


        public async Task<FlowerModel> AddFlower(AddFlowerModel model, string? userId)
        {
            var user = await userAccountService.GetByIdAsync(userId ?? "") ?? throw new ProcessException(ProcessExceptionCode.NotFound, "User not found");

            var flower = MapObject<AddFlowerModel, Flower>.GetMapObject()
                .CustomMap(d => d.User, s => user)
                .CustomMap(d => d.Categories, s =>
                    categoryService.GetOrAddCategories(s.Categories).Result)
                .Get(model);


            await context.Flowers.AddAsync(flower);
            await context.SaveChangesAsync();

            //var result = MapObject<Flower, FlowerModel>.GetMapObject()
            //    .CustomMap(d => d.Categories, s => s.Categories.Select(c => c.Name).ToArray())
            //    .Get(flower);

            return (FlowerModel)flower;
        }

        public async Task DeleteFlower(int id)
        {
            var flower = await context.Flowers.FindAsync(id)
                ?? throw new ProcessException(ProcessExceptionCode.NotFound,
                $"The flower (id: {id}) was not found");
            context!.Remove(flower);
            await context.SaveChangesAsync();
        }

        public async Task<FlowerModel?> GetFlower(int id)
        {
            var flower = await context.Flowers.FirstOrDefaultAsync(x => x.Id == id);
            if (flower == null) return null;
            return flower;
        }


        public async Task<IEnumerable<FlowerModel>> GetFlowers(int page = 1, int limit = 10, string? userId = null)
        {
            User? user = null;

            if (!string.IsNullOrWhiteSpace(userId))
            {
                user = await userAccountService.GetByIdAsync(userId) ?? throw new ProcessException(ProcessExceptionCode.NotFound, "User not found");
            }

            var flowers = context.Flowers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(userId))
            {
                flowers = flowers.Where(f => f.User == user);
            }

            flowers = flowers
                .Skip(Math.Max(0, page - 1) * limit)
                .Take(Math.Min(1000, limit));

            return await flowers.Select(s => (FlowerModel)s).ToListAsync();
        }

        public async Task<int> GetFlowersCount(string? userId = null)
        {
            User? user = null;

            if (!string.IsNullOrWhiteSpace(userId))
            {
                user = await userAccountService.GetByIdAsync(userId) ?? throw new ProcessException(ProcessExceptionCode.NotFound, "User not found");
            }

            var flowers = context.Flowers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(userId))
            {
                flowers = flowers.Where(f => f.User == user);
            }

            return flowers.Count();
        }

        public async Task UpdateFlower(int id, UpdateFlowerModel model)
        {
            var flower = await context!.Flowers!.FirstOrDefaultAsync(x => x.Id == id);
            ProcessException.ThrowIf(() => flower is null, $"The flower (id: {id}) was not found");

            var categories = await categoryService.GetOrAddCategories(model.Categories
                ?? Array.Empty<string>());

            flower?.Categories?.Clear();
            if (categories.Any())
            {
                flower?.Categories?.AddRange(categories);
            }


            MapObject<UpdateFlowerModel, Flower>.GetMapObject()
                .Ignore(x => x.Id)
                .Ignore(x => x.Uid)
                .Ignore(x => x.User)
                .Ignore(x => x.Categories)
                .Copy(model, flower!);

            context.Flowers.Update(flower!);
            await context.SaveChangesAsync();
        }
    }
}
