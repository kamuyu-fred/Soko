using Soko.API.Dtos;
using Soko.API.Entities;



namespace Soko.API.Mapping;

public static class CategoryMapping
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto(category.CategoryId, category.CategoryName);
    }
}
