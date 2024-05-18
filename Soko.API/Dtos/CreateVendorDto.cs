using System.ComponentModel.DataAnnotations;

namespace Soko.API;

public record class CreateVendorDto(

    [Required][StringLength(50)]string VendorName,
    [Required]int VendorPhone,
    [Required][StringLength(20)] string VendorLocation

);
