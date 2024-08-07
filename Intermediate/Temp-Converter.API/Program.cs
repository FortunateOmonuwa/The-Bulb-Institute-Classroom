using Temp_Converter.API.Interface;
using Temp_Converter.API.Models;
using Temp_Converter.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//////////////////////////////////////////////////////////
builder.Services.AddTransient<ITemperature, TemperateRepository>();
builder.Services.AddSingleton<IAccount, AccountRepository>();
builder.Services.AddHttpClient<IAccount, AccountRepository>();

var app = builder.Build();

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
