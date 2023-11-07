using Microsoft.EntityFrameworkCore;
using PetCare.Data;
using PetCare.Modules.Owner;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IOwnerService, OwnerService>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<PetCareContext>(
        options => options.UseSqlite(builder.Configuration.GetConnectionString("PetCareContext"))
    );
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.SeedData();

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
