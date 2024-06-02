using Soko.API.Data;
using Soko.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Soko");
builder.Services.AddSqlite<SokoContext>(connString);

var app = builder.Build();

app.MapProductsEndpoints();
app.MapCategoriesEndpoints();
app.MapVendorsEndpoints();
app.MapCustomersEndpoints(); 
app.MapBuyTransactionEndpoints();
app.MapSellTransactionEndpoints();
app.MapPOSBuyEndpoints();
app.MapPOSSellEndpoints();

 



await app.MigrateDbAsync();

app.Run();