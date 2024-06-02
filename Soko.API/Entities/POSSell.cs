using System.ComponentModel.DataAnnotations;


namespace Soko.API.Entities;

public class POSSell
{
    [Key]
    public int PSTId{ get; set; }
    public required string PTCustomerName{ get; set; }

    public int PSTQuantity{ get; set; }
    public int PTProductId { get; set; }
    public required string PTProductName { get; set; }
    public decimal PTSellPrice { get; set; }
    public DateTime PSellTransactionDate { get; set; }
}
