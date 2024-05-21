using System.ComponentModel.DataAnnotations;


namespace Soko.API.Dtos;

public record class SellTransactionDto(

   int SellTransactionId,
   string TCustomerName,
   int TQuantity,
   int TProductId,
   string TProductName,
   decimal TSellPrice,
   decimal TSellTotal,
   DateTime SellTransactionDate

);