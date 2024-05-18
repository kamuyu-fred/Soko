using Soko.API.Data;
using Soko.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Soko");
builder.Services.AddSqlite<SokoContext>(connString);

var app = builder.Build();

app.MapProductsEndpoints();
app.MapCategoriesEndpoints();


await app.MigrateDbAsync();

app.Run();