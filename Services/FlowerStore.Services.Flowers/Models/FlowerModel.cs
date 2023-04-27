using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;

namespace FlowerStore.Services.Flowers.Models;

public class FlowerModel
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Desription { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public int Count { get; set; }
    public string[]? Categories { get; set; }

    public static implicit operator FlowerModel(Flower flower)
    {
        return new FlowerModel
        {
            Id = flower.Id,
            Name = flower.Name,
            Desription = flower.Desription,
            Price = flower.Price,
            Count = flower.Count,
            Categories = flower.Categories?.Select(c => c.Name!).ToArray()
        };
    }
}
