
using Soko.API.Data;
using Soko.API.Dtos;
using Soko.API.Entities;
using Soko.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Soko.API.Endpoints;

public static class CustomersEndpoints
{

    const string GetCustomerEndpointName = "GetCustomer";



 public static RouteGroupBuilder MapCustomersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("customers")
                       .WithParameterValidation();

        // GET /vendors
        group.MapGet("/", async (SokoContext dbContext) => 
            await dbContext.Customers
                     
                     .Select(customer => customer.ToCustomerDetailsDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /vendors/1
        group.MapGet("/{CustomerId}", async (int CustomerId, SokoContext dbContext) =>
        {
            Customer? customer = await dbContext.Customers.FindAsync(CustomerId);

            return customer is null ? 
                Results.NotFound() : Results.Ok(customer.ToCustomerDetailsDto());
        })
        .WithName(GetCustomerEndpointName);

        // POST /vendors
        group.MapPost("/", async (CreateCustomerDto newCustomer, SokoContext dbContext) =>
        {
            Customer customer = newCustomer.ToEntity();

            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetCustomerEndpointName, 
                new { CustomerId = customer.CustomerId }, 
                customer.ToCustomerDetailsDto());
        });

        // PUT /vendors
        group.MapPut("/{CustomerId}", async (int CustomerId, UpdateCustomerDto updatedCustomer, SokoContext dbContext) =>
        {
            var existingCustomer = await dbContext.Customers.FindAsync(CustomerId);

            if (existingCustomer is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingCustomer)
                     .CurrentValues
                     .SetValues(updatedCustomer.ToEntity(CustomerId));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /vendors/1
        group.MapDelete("/{CustomerId}", async (int CustomerId, SokoContext dbContext) =>
        {
            await dbContext.Customers
                     .Where(vendor => vendor.CustomerId == CustomerId)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
