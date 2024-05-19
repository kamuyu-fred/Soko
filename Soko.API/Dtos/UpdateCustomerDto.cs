using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class UpdateCustomerDto(
    
    [Required][StringLength(50)] string CustomerName,
    [Required] string CustomerPhone,
    [Required][StringLength(20)] string CustomerLocation,
    DateOnly CustomerAddedDate
);