using System.ComponentModel.DataAnnotations;


namespace Soko.API.Dtos;

public record class SellTransactionDto(

   int SellTransactionId,
   string CustomerName,
   int Quantity,
   int ProductId,
   string ProductName,
   decimal SellPrice,
   decimal SellTotal,
   DateTime SellTransactionDate

);