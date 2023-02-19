using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;

namespace FlowerStore.Services.Flowers.Models;

public class AddFlowerModel
{
    public string Name { get; set; } = string.Empty;
    public string Desription { get; set; } = string.Empty;


    public static implicit operator AddFlowerModel(Flower flower)
    {
        return new AddFlowerModel
        {
            Name = flower.Name,
            Desription = flower.Desription
        };
    }

    public static implicit operator Flower(AddFlowerModel model)
    {
        return new Flower{
            Name = model.Name,
            Desription = model.Desription
        };
    }
}