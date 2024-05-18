using Soko.API.Dtos;
using Soko.API.Entities;

namespace Soko.API.Mapping;

public static class ProductMapping
{
    public static Product ToEntity(this CreateProductDto product)
    {
        return new Product()
        {
            ProductName = product.ProductName,
            Quantity = product.Quantity,
            CategoryId = product.CategoryId,
            BuyPrice = product.BuyPrice,
            SellPrice = product.BuyPrice,
            AddedDate = product.AddedDate
        };
    }

    public static Product ToEntity(this UpdateProductDto product, int ProductId)
    {
        return new Product()
        {
            ProductId = ProductId,
            ProductName = product.ProductName,
            CategoryId = product.CategoryId,
            BuyPrice = product.BuyPrice,
            AddedDate = product.AddedDate,
            
        };
    }    

    public static ProductSummaryDto ToProductSummaryDto(this Product product)
    {
        return new(
            product.Quantity,
            product.ProductId,
            product.ProductName,
            product.Category!.CategoryName,
            product.BuyPrice,
            product.SellPrice,
            product.AddedDate
            

        );
    }

    public static ProductDetailsDto ToProductDetailsDto(this Product product)
    {
        return new(
            product.ProductId,
            product.Quantity,
            product.CategoryId,
            product.ProductName,
            product.BuyPrice,
            product.SellPrice,
            product.AddedDate
        );
    }    
}
