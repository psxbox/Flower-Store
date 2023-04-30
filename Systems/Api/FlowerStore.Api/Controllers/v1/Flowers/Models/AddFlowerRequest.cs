using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.Flowers.Models;
using ObjectMapper;

namespace FlowerStore.Api.Controllers.v1.Flowers.Models
{
    /// <summary>
    /// <c>AddFlowerRequest</c> model
    /// </summary>
    public class AddFlowerRequest
    {   
        /// <summary>
        /// Flower name
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Flower description
        /// </summary>
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Price
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Count
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Categories
        /// </summary>
        public string[]? Categories { get; set; } 

        /// <summary>
        /// Converts <see cref="AddFlowerRequest"/> to <see cref="AddFlowerModel"/>
        /// </summary>
        /// <param name="addFlowerRequest"></param>
        public static implicit operator AddFlowerModel(AddFlowerRequest addFlowerRequest)
        {
            return MapObject<AddFlowerRequest, AddFlowerModel>.GetMapObject()
                .Get(addFlowerRequest);
        }
    }
}