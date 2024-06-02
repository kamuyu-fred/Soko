using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class CreateBuyTransactionDto(

  
    int BTId,
    [Required][StringLength(50)]
    string TVendorName,
    int BTQuantity,
    int TProductId,
    string TProductName,
    decimal TBuyPrice,
    DateTime BuyTransactionDate

);