using Microsoft.EntityFrameworkCore;
using WebAppASPWithReact.Server.Models;
using WebAppASPWithReact.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:5173") // Your React app URL
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStringDB")));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookCategoryService, BookCategoryService>();

var app = builder.Build();

// Use CORS policy
app.UseCors("AllowSpecificOrigin");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
