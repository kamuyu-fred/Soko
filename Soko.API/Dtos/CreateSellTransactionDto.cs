using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class CreateSellTransactionDto(

  
    int STId,
     [Required][StringLength(50)]
    string TCustomerName,
    int STQuantity,
    int TProductId,
    string TProductName,
    decimal TSellPrice,
    DateTime SellTransactionDate

);