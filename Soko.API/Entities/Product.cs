namespace Soko.API.Entities;

public class Product
{
    public int ProductId { get; set; }

    public int Quantity{ get; set; }

    public required string ProductName { get; set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public decimal BuyPrice { get; set; }

    public decimal SellPrice { get; set; }

    public DateOnly AddedDate { get; set; }
}
