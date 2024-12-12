using backend.data;
using backend.Interfaces;
using backend.Repository;
using backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//place before builder
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddScoped<IBrokerRepository, BrokerRepository>();
builder.Services.AddScoped<IBrokerService, BrokerService>();
builder.Services.AddScoped<IHouseService, HouseService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.MapOpenApi();
   app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//swagger wont work without this ->
app.MapControllers();

app.Run();


