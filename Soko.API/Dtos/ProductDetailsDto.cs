namespace Soko.API.Dtos;

public record class ProductDetailsDto(
    int ProductId,
    int Quantity,
    int CategoryId, 
    string ProductName, 
    decimal BuyPrice,
    decimal SellPrice,
    DateOnly AddedDate);