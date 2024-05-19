using System.ComponentModel.DataAnnotations;


namespace Soko.API.Dtos;

public record class BuyTransactionDto(

   int BuyTransactionId,
   string VendorName,
   int Quantity,
   int ProductId,
   string ProductName,
   decimal BuyPrice,
   decimal BuyTotal,
   DateTime BuyTransactionDate

);