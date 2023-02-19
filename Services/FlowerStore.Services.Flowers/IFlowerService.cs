using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.Flowers.Models;

namespace FlowerStore.Services.Flowers
{
    public interface IFlowerService
    {
       Task<IEnumerable<FlowerModel>> GetFlowers(int page = 0, int limit = 10);
       Task<FlowerModel?> GetFlower(int id);
       Task<FlowerModel> AddFlower(AddFlowerModel model);
       Task UpdateFlower(int id, UpdateFlowerModel model);
       Task DeleteFlower(int id);
       Task<int> GetFlowersCount();
    }
}