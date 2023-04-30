using FlowerStore.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersStore.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetOrAddCategories(string[]? categories);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
