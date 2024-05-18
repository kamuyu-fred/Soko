namespace Soko.API.Dtos;

public record class CustomerDetailsDto(

   int CustomerId,
   string CustomerName,
   int CustomerPhone,
   string CustomerLocation,
   DateOnly CustomerAddedDate
   



);
