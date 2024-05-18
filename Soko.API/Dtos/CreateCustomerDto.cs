using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class CreateCustomerDto(
   
    [Required][StringLength(50)] string CustomerName,
    [Required] int CustomerPhone,
    [Required][StringLength(20)] string CustomerLocation,
    DateOnly CustomerAddedDate
);