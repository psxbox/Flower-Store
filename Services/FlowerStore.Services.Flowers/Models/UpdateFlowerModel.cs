using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FlowerStore.Context.Entities;

namespace FlowerStore.Services.Flowers.Models;

public class UpdateFlowerModel
{
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public int Count { get; set; }
    public string[]? Categories { get; set; }

    //public static implicit operator Flower(UpdateFlowerModel flower)
    //{
    //    return new Flower
    //    {
    //        Name = flower.Name,
    //        Desription = flower.Desription,
    //        Price = flower.Price,
    //        Count = flower.Count
    //    };
    //}

}
