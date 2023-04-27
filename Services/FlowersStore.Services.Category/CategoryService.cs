using FlowerStore.Context;
using FlowerStore.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MainDbContext context;

        public CategoryService(MainDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category>> GetOrAddCategories(string[]? categories)
        {
            var result = new List<Category>();
            if (categories != null)
            {
                foreach (var category in categories)
                {
                    var founded = await context.Categories.FirstOrDefaultAsync(c => c.Name == category)
                        ?? new Category { Name = category };
                    result.Add(founded);
                }
            }
            return result;
        }
    }
}
