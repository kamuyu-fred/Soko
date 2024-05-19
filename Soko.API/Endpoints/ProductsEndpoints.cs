
using Soko.API.Data;
using Soko.API.Dtos;
using Soko.API.Entities;
using Soko.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Soko.API.Endpoints;

public static class ProductsEndpoints
{

    const string GetProductEndpointName = "GetProduct";



 public static RouteGroupBuilder MapProductsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("products")
                       .WithParameterValidation();

        // GET /products
        group.MapGet("/", async (SokoContext dbContext) => 
            await dbContext.Products
                     .Include(product => product.Category)
                     .Select(product => product.ToProductSummaryDto())
                     .AsNoTracking()
                     .ToListAsync());

        // GET /products/1
        group.MapGet("/{ProductId}", async (int ProductId, SokoContext dbContext) =>
        {
            Product? product = await dbContext.Products.FindAsync(ProductId);

            return product is null ? 
                Results.NotFound() : Results.Ok(product.ToProductDetailsDto());
        })
        .WithName(GetProductEndpointName);

        // POST /products
        group.MapPost("/", async (CreateProductDto newProduct, SokoContext dbContext) =>
        {
            Product product = newProduct.ToEntity();

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetProductEndpointName, 
                new { ProductId = product.ProductId }, 
                product.ToProductDetailsDto());
        });

        // PUT /products
        group.MapPut("/{productId}", async (int ProductId, UpdateProductDto updatedProduct, SokoContext dbContext) =>
        {
            var existingProduct = await dbContext.Products.FindAsync(ProductId);

            if (existingProduct is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingProduct)
                     .CurrentValues
                     .SetValues(updatedProduct.ToEntity(ProductId));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /products/1
        group.MapDelete("/{ProductId}", async (int ProductId, SokoContext dbContext) =>
        {
            await dbContext.Products
                     .Where(product => product.ProductId == ProductId)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
