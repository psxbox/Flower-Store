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
        private readonly MainDbContext context;

        public FlowerService(MainDbContext context)
        {
            this.context = context;
        }

        public async Task<FlowerModel> AddFlower(AddFlowerModel model)
        {
            var res = await context!.Flowers!.AddAsync(model);
            await context.SaveChangesAsync();
            return (FlowerModel)res.Entity;
        }

        public async Task DeleteFlower(int id)
        {
            var flower = await context!.Flowers!.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ProcessException($"The flower (id: {id}) was not found");
            context!.Remove(flower);
            await context.SaveChangesAsync();
        }

        public async Task<FlowerModel?> GetFlower(int id)
        {
            var flower = await context!.Flowers!.FirstOrDefaultAsync(x => x.Id == id);

            return flower;
        }

        public async Task<IEnumerable<FlowerModel>> GetFlowers(int page = 0, int limit = 10)
        {
            var flowers = context!.Flowers!
                .Skip(Math.Max(0, page) * limit)
                .Take(Math.Min(1000, limit))
                .Select(s => (FlowerModel)s);
            return await flowers.ToListAsync();
        }

        public Task<int> GetFlowersCount()
        {
            return Task.FromResult(context!.Flowers!.Count());
        }

        public async Task UpdateFlower(int id, UpdateFlowerModel model)
        {
            var flower = await context!.Flowers!.FirstOrDefaultAsync(x => x.Id == id);
            ProcessException.ThrowIf(() => flower is null, $"The flower (id: {id}) was not found");

            flower = model;
            flower.Id = id;

            context!.Flowers!.Update(flower);
            await context.SaveChangesAsync();
        }
    }
}
