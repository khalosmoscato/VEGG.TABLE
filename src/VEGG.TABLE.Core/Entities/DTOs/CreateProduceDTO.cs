namespace VEGG.TABLE.Core.Entities;


public class CreateProduceDTO
{
    public required string Name { get; set; }
    public int Stock { get; set; } = 0;
    public double Price { get; set; } = 0;
    public double Weight { get; set; } = 0;
    public Category Category { get; set; } = Category.Unkown;
    public string Description { get; set; } = string.Empty;
    public string PhotograghPath { get; set; } = string.Empty;
    public bool IsOnSale { get; set; } = false;
    public int UserId { get; set; }

}