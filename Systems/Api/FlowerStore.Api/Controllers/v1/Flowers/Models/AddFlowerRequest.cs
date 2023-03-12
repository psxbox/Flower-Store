using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.Flowers.Models;

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
        public string Desription { get; set; } = string.Empty;

        /// <summary>
        /// Converts <see cref="AddFlowerRequest"/> to <see cref="AddFlowerModel"/>
        /// </summary>
        /// <param name="addFlowerRequest"></param>
        public static implicit operator AddFlowerModel(AddFlowerRequest addFlowerRequest)
        {
            return new AddFlowerModel
            {
                Name = addFlowerRequest.Name,
                Desription = addFlowerRequest.Desription
            };
        }
    }
}