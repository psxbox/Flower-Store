using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;
using FlowerStore.Services.Flowers.Models;

namespace FlowerStore.Services.Flowers
{
    public class MockFlowerService : IFlowerService
    {
        private List<Flower> _flowers;

        public MockFlowerService()
        {
            _flowers = GenerateFlowers();
        }

        private List<Flower> GenerateFlowers()
        {
            return new() {
                new Flower 
                {
                    Id = 1,
                    Name = "Гвоздика"
                },
                new Flower 
                {
                    Id = 2,
                    Name = "Лилия"
                },
                new Flower 
                {
                    Id = 3,
                    Name = "Роза"
                },
                new Flower 
                {
                    Id = 4,
                    Name = "Ромашка"
                },
            };
        }

        public Task<FlowerModel> AddFlower(AddFlowerModel model)
        {
            Flower flower = model;
            if (flower.Id == 0) {
                flower.Id = _flowers.Max(f => f.Id) + 1;
            }
            _flowers.Add(flower);
            return Task.FromResult((FlowerModel)flower);
        }

        public Task DeleteFlower(int id)
        {
            _flowers.RemoveAt(id);
            return Task.CompletedTask;
        }

        public Task<FlowerModel?> GetFlower(int id)
        {
            var flower = _flowers.FirstOrDefault(item => item.Id == id);
            
            return Task.FromResult((FlowerModel?)flower);
        }

        public Task<IEnumerable<FlowerModel>> GetFlowers(int page = 0, int limit = 10)
        {
            IEnumerable<FlowerModel> flowerModels = _flowers
                .Skip(Math.Max(0, page) * limit)
                .Take(Math.Min(1000, limit))
                .Select(s => (FlowerModel)s);

            return Task.FromResult(flowerModels);
        }

        public Task UpdateFlower(int id, UpdateFlowerModel model)
        {
            var flower = _flowers.FirstOrDefault(f => f.Id == id);

            if (flower is null)
                throw new($"The flower with id:{id} not found.");
            
            flower.Name = model.Name;
            flower.Desription = model.Desription;
            return Task.CompletedTask;
        }

        public Task<int> GetFlowersCount()
        {
            return Task.FromResult(_flowers.Count);
        }
    }
}