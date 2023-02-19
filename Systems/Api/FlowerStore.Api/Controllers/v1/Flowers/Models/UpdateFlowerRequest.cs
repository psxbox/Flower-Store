using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Services.Flowers.Models;

namespace FlowerStore.Api.Controllers.v1.Flowers.Models
{
    /// <summary>
    /// <c>UpdateFlowerRequest</c> model
    /// </summary>
    public class UpdateFlowerRequest
    {
        [Required(ErrorMessage = "Name is required"), StringLength(50)]
        public string Name { get; set; } = string.Empty;
        public string Desription { get; set; } = string.Empty;

        /// <summary>
        /// Convert <see cref="UpdateFlowerRequest"/> to <see cref="UpdateFlowerModel"/>
        /// </summary>
        /// <param name="updateFlowerRequest"></param>
        public static implicit operator UpdateFlowerModel(UpdateFlowerRequest updateFlowerRequest)
        {
            return new UpdateFlowerModel
            {
                Name = updateFlowerRequest.Name,
                Desription = updateFlowerRequest.Desription
            };
        }
    }
}