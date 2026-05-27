namespace VEGG.TABLE.Core.Entities;

public class Produce
{
    public required int ProduceId { get; set; }
    public required string Name { get; set; }
    public int Stock { get; set; } = 0;
    public double Price { get; set; } = 0;
    public double Weight { get; set; } = 0;
    public Category Category { get; set; } = Category.Unkown;
    public string Description { get; set; } = string.Empty;
    public string PhotograghPath { get; set; } = string.Empty;

    public bool IsLiked { get; set; } = false;
    public bool IsOnSale { get; set; } = false;
    public bool IsPurchased { get; set; } = false;

    public required int UserId { get; set; }
}
public enum Category
{
    LeafyGreens,       // Spinach, Kale, Lettuce, Cabbage
    Cruciferous,       // Broccoli, Cauliflower, Brussels Sprouts
    RootAndTuber,      // Carrots, Potatoes, Beets, Parsnips
    Allium,            // Onions, Garlic, Leeks, Shallots
    FruitVegetables,   // Tomatoes, Peppers, Cucumbers, Eggplants, Squash
    PodsAndSeeds,      // Peas, Green Beans, Sweetcorn
    StemsAndShoots,    // Asparagus, Celery, Fennel
    Mushrooms,         // Button, Shiitake, Portobello (Fungi)
    Herbs,              // Parsley, Basil, Cilantro, Mint
    Unkown
}
