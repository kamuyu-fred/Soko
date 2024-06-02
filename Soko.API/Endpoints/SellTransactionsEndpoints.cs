

using Soko.API.Data;
using Soko.API.Dtos;
using Soko.API.Entities;
using Soko.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Soko.API.Endpoints;

public static class SellTransactionsEndpoints
{

    const string GetSellTransactionEndpointName = "GetSellTransaction";



 public static RouteGroupBuilder MapSellTransactionEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("selltransactions")
                       .WithParameterValidation();

        // GET /buytransactions
        group.MapGet("/", async (SokoContext dbContext) => 
            await dbContext.SellTransactions
                     
                     .Select(selltransaction => selltransaction.ToSellTransactionDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /buytransactions/1
        group.MapGet("/{STId}", async (int STId, SokoContext dbContext) =>
        {
            SellTransaction? selltransaction = await dbContext.SellTransactions.FindAsync(STId);

            return selltransaction is null ? 
                Results.NotFound() : Results.Ok(selltransaction.ToSellTransactionDto());
        })
        .WithName(GetSellTransactionEndpointName);

        // POST /buytransactions
        group.MapPost("/", async (CreateSellTransactionDto newSellTransaction, SokoContext dbContext) =>
        {
            SellTransaction selltransaction = newSellTransaction.ToEntity();

            dbContext.SellTransactions.Add(selltransaction);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetSellTransactionEndpointName, 
                new { STId = selltransaction.STId }, 
                selltransaction.ToSellTransactionDto());
        });
        
        
        
         // DELETE /products/1
        group.MapDelete("/{STId}", async (int STId, SokoContext dbContext) =>
        {
            await dbContext.SellTransactions
                     .Where(selltransaction => selltransaction.STId == STId)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });


       
    return group;
    }
}
