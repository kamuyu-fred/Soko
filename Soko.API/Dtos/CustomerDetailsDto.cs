namespace Soko.API.Dtos;

public record class CustomerDetailsDto(

   int CustomerId,
   string CustomerName,
   string CustomerPhone,
   string CustomerLocation,
   DateOnly CustomerAddedDate
   



);
