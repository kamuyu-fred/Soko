using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class UpdateVendorDto(
    
    [Required][StringLength(50)] string VendorName,
    [Required] int VendorPhone,
    [Required][StringLength(20)] string VendorLocation
    
);