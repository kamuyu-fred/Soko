using Soko.API.Data;
using Soko.API.Entities;
using Soko.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Soko.API.Endpoints;

public static class CategoriesEndpoints
{

   

    public static RouteGroupBuilder MapCategoriesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("categories");

        group.MapGet("/", async (SokoContext dbContext) =>
            await dbContext.Categories
                           .Select(category => category.ToDto())
                           .AsNoTracking()
                           .ToListAsync());

        return group;
    }
}