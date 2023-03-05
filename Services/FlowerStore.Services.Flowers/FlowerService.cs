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

namespace FlowerStore.Services.Flowers
{
    public class FlowerService : IFlowerService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public FlowerService(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<FlowerModel> AddFlower(AddFlowerModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var res = await context!.Flowers!.AddAsync(model);
            await context.SaveChangesAsync();
            return (FlowerModel)res.Entity;
        }

        public async Task DeleteFlower(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var flower = await context!.Flowers!.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ProcessException($"The flower (id: {id}) was not found");
            context!.Remove(flower);
            await context.SaveChangesAsync();
        }

        public async Task<FlowerModel?> GetFlower(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var flower = await context!.Flowers!.FirstOrDefaultAsync(x => x.Id == id);

            return flower;
        }

        public async Task<IEnumerable<FlowerModel>> GetFlowers(int page = 0, int limit = 10)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var flowers = context!.Flowers!
                .Skip(Math.Max(0, page) * limit)
                .Take(Math.Min(1000, limit))
                .Select(s => (FlowerModel)s);
            return await flowers.ToListAsync();
        }

        public async Task<int> GetFlowersCount()
        {
            using var context = await contextFactory.CreateDbContextAsync();
            return context!.Flowers!.Count();
        }

        public async Task UpdateFlower(int id, UpdateFlowerModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var flower = await context!.Flowers!.FirstOrDefaultAsync(x => x.Id == id);
            ProcessException.ThrowIf(() => flower is null, $"The flower (id: {id}) was not found");

            flower = model;
            flower.Id = id;

            context!.Flowers!.Update(flower);
            await context.SaveChangesAsync();
        }
    }
}
