using Book_Management.Models;
using Book_Management.Repositories;
using Book_Management.Repositories.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Getting the Connection String
builder.Services.AddDbContext<BookmanagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("con")));
// Adding the Repository Scope
builder.Services.AddScoped<IbookInterface, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger();
   
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
