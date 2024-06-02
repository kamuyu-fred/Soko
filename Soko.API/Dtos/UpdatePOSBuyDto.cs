using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class UpdatePOSBuyDto(

   
   int PBTId,
   [Required][StringLength(50)]
   string PTVendorName,
   int PBTQuantity,
   int PTProductId,
   string PTProductName,
   decimal PTBuyPrice,
   DateTime PBuyTransactionDate

);