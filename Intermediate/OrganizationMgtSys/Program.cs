using Microsoft.EntityFrameworkCore;
using OrganizationMgtSys.DataAccess.DataContext;
using OrganizationMgtSys.DataAccess.Interfaces;
using OrganizationMgtSys.DataAccess.Repositories;
using OrganizationMgtSys.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// Register DBContext as a service.
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});
//Register Automapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IBaseService<Company>, CompanyRepository>();
builder.Services.AddTransient<IBaseService<Staff>, StaffRepository>();

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
