
using Soko.API.Data;
using Soko.API.Dtos;
using Soko.API.Entities;
using Soko.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Soko.API.Endpoints;

public static class VendorsEndpoints
{

    const string GetVendorEndpointName = "GetVendor";



 public static RouteGroupBuilder MapVendorsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("vendors")
                       .WithParameterValidation();

        // GET /vendors
        group.MapGet("/", async (SokoContext dbContext) => 
            await dbContext.Vendors
                     
                     .Select(vendor => vendor.ToVendorDetailsDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /vendors/1
        group.MapGet("/{VendorId}", async (int VendorId, SokoContext dbContext) =>
        {
            Vendor? vendor = await dbContext.Vendors.FindAsync(VendorId);

            return vendor is null ? 
                Results.NotFound() : Results.Ok(vendor.ToVendorDetailsDto());
        })
        .WithName(GetVendorEndpointName);

        // POST /vendors
        group.MapPost("/", async (CreateVendorDto newVendor, SokoContext dbContext) =>
        {
            Vendor vendor = newVendor.ToEntity();

            dbContext.Vendors.Add(vendor);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetVendorEndpointName, 
                new { VendorId = vendor.VendorId }, 
                vendor.ToVendorDetailsDto());
        });

        // PUT /vendors
        group.MapPut("/{VendorId}", async (int VendorId, UpdateVendorDto updatedVendor, SokoContext dbContext) =>
        {
            var existingVendor = await dbContext.Vendors.FindAsync(VendorId);

            if (existingVendor is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingVendor)
                     .CurrentValues
                     .SetValues(updatedVendor.ToEntity(VendorId));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /vendors/1
        group.MapDelete("/{VendorId}", async (int VendorId, SokoContext dbContext) =>
        {
            await dbContext.Vendors
                     .Where(vendor => vendor.VendorId == VendorId)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
