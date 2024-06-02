using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class UpdatePOSSellDto(

  
    int PSTId,
     [Required][StringLength(50)]
    string PTCustomerName,
    int PSTQuantity,
    int PTProductId,
    string PTProductName,
    decimal PTSellPrice,
    DateTime PSellTransactionDate

);