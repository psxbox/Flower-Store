using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;

namespace FlowerStore.Services.Flowers.Models;

public class UpdateFlowerModel
{
    public string Name { get; set; } = string.Empty;
    public string Desription { get; set; } = string.Empty;

    public static implicit operator Flower(UpdateFlowerModel flower)
    {
        return new Flower
        {
            Name = flower.Name,
            Desription = flower.Desription
        };
    }

}
