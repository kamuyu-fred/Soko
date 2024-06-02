using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class SellTransactionDto(

   int STId,
   [Required][StringLength(50)]
   string TCustomerName,
   int STQuantity,
   int TProductId,
   string TProductName,
   decimal TSellPrice,
   DateTime SellTransactionDate

);