namespace Soko.API.Entities;

public class BuyTransaction
{
    public int TProductId { get; set; }

    public int TQuantity{ get; set; }

    public required string TProductName { get; set; }


    public Category? Category { get; set; }

    public decimal TBuyPrice { get; set; }

    public decimal TSellPrice { get; set; }

    public DateTime BuyTransactionDate { get; set; }
}
