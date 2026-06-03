using System;
using System.Collections.Generic;
using System.Text;

namespace VEGG.TABLE.UnitTests.Resources;

internal class DummyProduce
{
    public static readonly List<Produce> DummyProduceList = new List<Produce>
    {
    new()
    {
        ProduceId = 1,
        Name = "Spinach",
        Stock = 50,
        Price = 1.99,
        Weight = 0.25,
        Category = Category.LeafyGreens,
        Description = "Fresh baby spinach leaves.",
        PhotograghPath = "/images/spinach.jpg",
        IsOnSale = false,
        IsLiked = true,
        IsPurchased = true,
        UserId = 1
    },
    new()
    {
        ProduceId = 2,
        Name = "Broccoli",
        Stock = 30,
        Price = 2.49,
        Weight = 0.45,
        Category = Category.Cruciferous,
        Description = "Organic broccoli crowns.",
        PhotograghPath = "/images/broccoli.jpg",
        IsOnSale = true,
        IsLiked = true,
        IsPurchased= true,
        UserId = 1
    },
    new()
    {
        ProduceId = 3,
        Name = "Broccoli",
        Stock = 40,
        Price = 2.79,
        Weight = 0.55,
        Category = Category.Cruciferous,
        Description = "Fresh green broccoli crowns.",
        PhotograghPath = "images/broccoli.jpg",
        IsLiked = true,
        IsOnSale = true,
        IsPurchased = false,
        UserId = 2
    },
    new()
    {
        ProduceId = 4,
        Name = "Cauliflower",
        Stock = 12,
        Price = 3.25,
        Weight = 0.80,
        Category = Category.Cruciferous,
        Description = "Large white cauliflower head.",
        PhotograghPath = "images/cauliflower.jpg",
        IsLiked = false,
        IsOnSale = false,
        IsPurchased = true,
        UserId = 2
    },

};
}
