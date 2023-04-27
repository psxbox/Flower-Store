using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.Flowers.Models;

namespace FlowerStore.Api.Controllers.v1.Flowers.Models
{
    /// <summary>
    /// <c>FlowerResponse</c> model
    /// </summary>
    public class FlowerResponse
    {
        /// <summary>
        /// Flower id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Flower name
        /// </summary>
        public string? Name { get; set; } = string.Empty;
        /// <summary>
        /// Flower description
        /// </summary>
        public string? Desription { get; set; } = string.Empty;
        /// <summary>
        /// Price
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Count
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Categories
        /// </summary>
        public string[]? Categories { get; set; }

        /// <summary>
        /// Convert <see cref="FlowerModel"/> to <see cref="FlowerResponse"/>
        /// </summary>
        /// <param name="flowerModel"></param>
        public static implicit operator FlowerResponse(FlowerModel flowerModel)
        {
            return new FlowerResponse
            {
                Id = flowerModel.Id,
                Name = flowerModel.Name,
                Desription = flowerModel.Desription,
                Price = flowerModel.Price,
                Count = flowerModel.Count,
                Categories = flowerModel.Categories,
            };
        }
    }
}