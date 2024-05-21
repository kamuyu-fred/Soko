using System.ComponentModel.DataAnnotations;


namespace Soko.API.Entities;

public class BuyTransaction
{
    [Key]
    public int BTId{ get; set; }
    public required string TVendorName{ get; set; }

    public int TQuantity{ get; set; }
    public int TProductId { get; set; }

    

   
    public required string TProductName { get; set; }
    public decimal TBuyPrice { get; set; }
    public DateTime BuyTransactionDate { get; set; }
}
