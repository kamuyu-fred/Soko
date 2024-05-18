using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class CreateProductDto(
    
    [Required][StringLength(50)] string ProductName,
    int Quantity,
    int CategoryId,
    decimal BuyPrice,
    decimal SellPrice,
    DateOnly AddedDate
);