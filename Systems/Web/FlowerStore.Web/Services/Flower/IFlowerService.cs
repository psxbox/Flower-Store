using FlowerStore.Web.Models.Flower;

namespace FlowerStore.Web.Services.Flower
{
    public interface IFlowerService
    {
        Task<FlowersResponce?> GetAllAsync(int page = 1, int limit = 10);
        Task<FlowerModel> GetByIdAsync(int id);
        Task AddFlowerAsync(FlowerModel model);
        Task UpdateFlowerAsync(int id, FlowerModel model);
        Task DeleteFlowerAsync(int id);
    }
}
