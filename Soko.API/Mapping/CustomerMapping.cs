using Soko.API.Dtos;
using Soko.API.Entities;

namespace Soko.API.Mapping;

public static class CustomerMapping
{
    public static Customer ToEntity(this CreateCustomerDto customer)
    {
        return new Customer()
        {   
            CustomerName = customer.CustomerName,
            CustomerPhone = customer.CustomerPhone,
            CustomerLocation = customer.CustomerLocation,
            CustomerAddedDate = customer.CustomerAddedDate
        };
    }

    public static Customer ToEntity(this UpdateCustomerDto customer, int CustomerId)
    {
        return new Customer()
        {
            CustomerId = CustomerId,
            CustomerName = customer.CustomerName,
            CustomerPhone = customer.CustomerPhone,
            CustomerLocation = customer.CustomerLocation,
            CustomerAddedDate = customer.CustomerAddedDate
            
        };
    }    

   

    public static CustomerDetailsDto ToCustomerDetailsDto(this Customer customer)
    {
        return new(

            customer.CustomerId,
            customer.CustomerName,
            customer.CustomerPhone,
            customer.CustomerLocation,
            customer.CustomerAddedDate
        );
    }    
}
