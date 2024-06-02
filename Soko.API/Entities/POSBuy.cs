using System.ComponentModel.DataAnnotations;


namespace Soko.API.Entities;

public class POSBuy
{
    [Key]
    public int PBTId{ get; set; }
    public required string PTVendorName{ get; set; }

    public int PBTQuantity{ get; set; }
    public int PTProductId { get; set; }
    public required string PTProductName { get; set; }
    public decimal PTBuyPrice { get; set; }
    public DateTime PBuyTransactionDate { get; set; }
}
