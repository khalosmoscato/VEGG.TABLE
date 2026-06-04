namespace VEGG.TABLE.Core.Entities;


public class CreateProduceDTO
{
    public required string Name { get; set; }
    public required int Stock { get; set; } = 0;
    public required double Price { get; set; } = 0;
    public double Weight { get; set; } = 0;
    public Category Category { get; set; } = Category.Unkown;
    public required string Description { get; set; } = string.Empty;
    public string PhotograghPath { get; set; } = string.Empty;
    public required bool IsOnSale { get; set; } = false;
    public required int UserId { get; set; }

}