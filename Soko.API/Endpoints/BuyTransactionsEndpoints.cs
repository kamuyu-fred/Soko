
using Soko.API.Data;
using Soko.API.Dtos;
using Soko.API.Entities;
using Soko.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Soko.API.Endpoints;

public static class BuyTransactionsEndpoints
{

    const string GetBuyTransactionEndpointName = "GetBuyTransaction";



 public static RouteGroupBuilder MapBuyTransactionEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("buytransactions")
                       .WithParameterValidation();

        // GET /buytransactions
        group.MapGet("/", async (SokoContext dbContext) => 
            await dbContext.BuyTransactions
                     
                     
                     .Select(buytransaction => buytransaction.ToBuyTransactionDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /buytransactions/1
        group.MapGet("/{BTId}", async (int BTId, SokoContext dbContext) =>
        {
            BuyTransaction? buytransaction = await dbContext.BuyTransactions.FindAsync(BTId);

            return buytransaction is null ? 
                Results.NotFound() : Results.Ok(buytransaction.ToBuyTransactionDto());
        })
        .WithName(GetBuyTransactionEndpointName);

        // POST /buytransactions
        group.MapPost("/", async (CreateBuyTransactionDto newBuyTransaction, SokoContext dbContext) =>
        {
            BuyTransaction buytransaction = newBuyTransaction.ToEntity();

            dbContext.BuyTransactions.Add(buytransaction);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetBuyTransactionEndpointName, 
                new { BTId = buytransaction.BTId }, 
                buytransaction.ToBuyTransactionDto());
        });

         // PUT /products
        group.MapPut("/{BTId}", async (int BTId, UpdateBuyTransactionDto updatedBuyTransaction, SokoContext dbContext) =>
        {
            var existingBuyTransaction = await dbContext.BuyTransactions.FindAsync(BTId);

            if (existingBuyTransaction is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingBuyTransaction)
                     .CurrentValues
                     .SetValues(updatedBuyTransaction.ToEntity(BTId));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });
        
        
        
         // DELETE /products/1
        group.MapDelete("/{BTId}", async (int BTId, SokoContext dbContext) =>
        {
            await dbContext.BuyTransactions
                     .Where(buytransaction => buytransaction.BTId == BTId)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });


       
    return group;
    }
}
