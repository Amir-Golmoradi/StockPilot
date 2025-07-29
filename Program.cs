using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.Interface;
using StockMarket.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IStockRepository, StockRepository>();
// Services
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();



// Swagger
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Middleware & Routing
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
