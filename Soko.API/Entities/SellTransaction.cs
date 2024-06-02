using System.ComponentModel.DataAnnotations;

namespace Soko.API.Entities;

public class SellTransaction
{
    [Key]

    public int STId { get; set; }
    public required string TCustomerName { get; set; }

    public int STQuantity{ get; set; }

    public int TProductId{ get; set; }
    public required string TProductName{ get; set; }

    public decimal TSellPrice{ get; set; }

    public DateTime SellTransactionDate { get; set; }
}
