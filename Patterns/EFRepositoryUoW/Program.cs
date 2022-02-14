using EFRepositoryUoW.Core.Configuration;
using EFRepositoryUoW.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSqlite<ApplicationDbContext>("DataSource=app.db");

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

// Adding the Unit of work to the DI container
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
