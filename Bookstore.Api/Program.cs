using Bookstore.Domain.Interfaces;
using Bookstore.Infrastructure.Context;
using Bookstore.Infrastructure.Mappings;
using Bookstore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookstoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));
builder.Services.AddSingleton(RT.Comb.Provider.Sql);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{

    //migrations
    var db = scope.ServiceProvider.GetRequiredService<BookstoreDbContext>();
    db.Database.Migrate();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
