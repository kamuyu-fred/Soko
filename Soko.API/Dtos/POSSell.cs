using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class POSSellDto(

   
   int STId,
   [Required][StringLength(50)]
   string PTCustomerName,
   int PSTQuantity,
   int PTProductId,
   string PTProductName,
   decimal PTSellPrice,
   DateTime PSellTransactionDate

);