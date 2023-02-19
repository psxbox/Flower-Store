using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;

namespace FlowerStore.Services.Flowers.Models;

public class FlowerModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Desription { get; set; } = string.Empty;

    public static implicit operator FlowerModel(Flower? flower)
    {
        if (flower is null) return null;
        return new FlowerModel
        {
            Id = flower.Id,
            Name = flower.Name,
            Desription = flower.Desription
        };
    }
}
