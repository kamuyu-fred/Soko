namespace Soko.API.Dtos;

public record class BuyTransactionDto(

   
   int BTId,
   string TVendorName,
   int TQuantity,
   int TProductId,
   string TProductName,
   decimal TBuyPrice,
   DateTime BuyTransactionDate

);