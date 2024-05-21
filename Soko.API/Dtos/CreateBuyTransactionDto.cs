namespace Soko.API.Dtos;

public record class CreateBuyTransactionDto(

  
    int BTId,
    string TVendorName,
    int TQuantity,
    int TProductId,
    string TProductName,
    decimal TBuyPrice,
    DateTime BuyTransactionDate

);