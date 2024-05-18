using System.ComponentModel.DataAnnotations;

namespace Soko.API.Dtos;

public record class UpdateProductDto(
     int Quantity,
    [Required][StringLength(50)] string ProductName,
    int CategoryId,
    decimal BuyPrice,
    decimal SellPrice,
    DateOnly AddedDate,
    string CategoryName
);
