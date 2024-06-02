
using Soko.API.Data;
using Soko.API.Dtos;
using Soko.API.Entities;
using Soko.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Soko.API.Endpoints;

public static class POSSellEndpoints
{

    const string GetPOSSellEndpointName = "GetPOSSell";



 public static RouteGroupBuilder MapPOSSellEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("pselltransactions")
                       .WithParameterValidation();

        // GET /buytransactions
        group.MapGet("/", async (SokoContext dbContext) => 
            await dbContext.POSSell
                     
                     
                     .Select(pselltransaction => pselltransaction.ToPOSSellDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /buytransactions/1
        group.MapGet("/{PSTId}", async (int PSTId, SokoContext dbContext) =>
        {
            POSSell? pselltransaction = await dbContext.POSSell.FindAsync(PSTId);

            return pselltransaction is null ? 
                Results.NotFound() : Results.Ok(pselltransaction.ToPOSSellDto());
        })
        .WithName(GetPOSSellEndpointName);

        // POST /buytransactions
        group.MapPost("/", async (CreatePOSSellDto newPOSSell, SokoContext dbContext) =>
        {
            POSSell pselltransaction = newPOSSell.ToEntity();

            dbContext.POSSell.Add(pselltransaction);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetPOSSellEndpointName, 
                new { PSTId = pselltransaction.PSTId }, 
                pselltransaction.ToPOSSellDto());
        });

         // PUT /products
        group.MapPut("/{PSTId}", async (int PSTId, UpdatePOSSellDto updatedPOSSell, SokoContext dbContext) =>
        {
            var existingPOSSell = await dbContext.POSSell.FindAsync(PSTId);

            if (existingPOSSell is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingPOSSell)
                     .CurrentValues
                     .SetValues(updatedPOSSell.ToEntity(PSTId));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });
        
        
        
         // DELETE /products/1
        group.MapDelete("/{PSTId}", async (int PSTId, SokoContext dbContext) =>
        {
            await dbContext.POSSell
                     .Where(pselltransaction => pselltransaction.PSTId == PSTId)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });


       
    return group;
    }
}
