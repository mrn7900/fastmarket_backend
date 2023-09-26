using fastmarket_backend.DataProvide;
using fastmarket_backend.Repos;
using fastmarket_backend.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<fastmarketContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<ISnakRepo, SnakRepo>();
builder.Services.AddScoped<IDrinkRepo, DrinkRepo>();
builder.Services.AddScoped<IDriedfruitRepo, DriedfruitRepo>();
builder.Services.AddScoped<IDairyRepo, DairyRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IBreakfastRepo, BreakfastRepo>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
