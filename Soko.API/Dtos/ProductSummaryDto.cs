namespace Soko.API.Dtos;

public record class ProductSummaryDto(
    
    int Quantity,
    int ProductId,
    string ProductName, 
    string CategoryName, 
    decimal BuyPrice,
    decimal SellPrice,
    DateOnly AddedDate);
