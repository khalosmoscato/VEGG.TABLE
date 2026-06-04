namespace VEGG.TABLE.Core.Entities;

public class ProduceDTO
{
    public string? Name { get; set; }
    public int? Stock { get; set; }
    public double? Price { get; set; }
    public double? Weight { get; set; }
    public Category? Category { get; set; }
    public string? Description { get; set; }
    public string? PhotograghPath { get; set; }
    public bool? IsOnSale { get; set; }
    public int? UserId { get; set; }
}