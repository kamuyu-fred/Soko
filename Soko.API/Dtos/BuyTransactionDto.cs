using System.ComponentModel.DataAnnotations;


namespace Soko.API.Dtos;

public record class BuyTransactionDto(

   int BuyTransactionId,
   string TVendorName,
   int TQuantity,
   int TProductId,
   string TProductName,
   decimal TBuyPrice,
   decimal TBuyTotal,
   DateTime BuyTransactionDate

);