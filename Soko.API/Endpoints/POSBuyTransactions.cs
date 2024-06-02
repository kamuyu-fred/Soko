
using Soko.API.Data;
using Soko.API.Dtos;
using Soko.API.Entities;
using Soko.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Soko.API.Endpoints;

public static class POSBuyEndpoints
{

    const string GetPOSBuyEndpointName = "GetPOSBuy";



 public static RouteGroupBuilder MapPOSBuyEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("pbuytransactions")
                       .WithParameterValidation();

        // GET /buytransactions
        group.MapGet("/", async (SokoContext dbContext) => 
            await dbContext.POSBuy
                     
                     
                     .Select(pbuytransaction => pbuytransaction.ToPOSBuyDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /buytransactions/1
        group.MapGet("/{PBTId}", async (int PBTId, SokoContext dbContext) =>
        {
            POSBuy? pbuytransaction = await dbContext.POSBuy.FindAsync(PBTId);

            return pbuytransaction is null ? 
                Results.NotFound() : Results.Ok(pbuytransaction.ToPOSBuyDto());
        })
        .WithName(GetPOSBuyEndpointName);

        // POST /buytransactions
        group.MapPost("/", async (CreatePOSBuyDto newPOSBuy, SokoContext dbContext) =>
        {
            POSBuy pbuytransaction = newPOSBuy.ToEntity();

            dbContext.POSBuy.Add(pbuytransaction);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetPOSBuyEndpointName, 
                new { PBTId = pbuytransaction.PBTId }, 
                pbuytransaction.ToPOSBuyDto());
        });

         // PUT /products
        group.MapPut("/{PBTId}", async (int PBTId, UpdatePOSBuyDto updatedPOSBuy, SokoContext dbContext) =>
        {
            var existingPOSBuy = await dbContext.POSBuy.FindAsync(PBTId);

            if (existingPOSBuy is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingPOSBuy)
                     .CurrentValues
                     .SetValues(updatedPOSBuy.ToEntity(PBTId));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });
        
        
        
         // DELETE /products/1
        group.MapDelete("/{PBTId}", async (int PBTId, SokoContext dbContext) =>
        {
            await dbContext.POSBuy
                     .Where(pbuytransaction => pbuytransaction.PBTId == PBTId)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });


       
    return group;
    }
}
