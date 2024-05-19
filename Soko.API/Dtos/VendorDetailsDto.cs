namespace Soko.API.Dtos;

public record class VendorDetailsDto(

    int VendorId,
    string VendorName,
    string VendorPhone,
    string VendorLocation,
    DateOnly VendorAddedDate

);

