using InventoryManagementAPI;
using InventoryManagementAPI.DataAccess.DataContext;
using InventoryManagementAPI.DataAccess.Interface;
using InventoryManagementAPI.DataAccess.Repository;
using InventoryManagementAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BaseString"));
});
builder.Services.Configure<BaseSetup>(builder.Configuration.GetSection("BaseSetup"));
builder.Services.AddTransient<IEmailService,EmailService>();
builder.Services.AddTransient<IRegister_Login, Logs>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
          //  ValidateAudience = true,
            ValidateIssuerSigningKey = true,
           // ValidAudience = builder.Configuration["BaseSetup:Audience"]
            ValidIssuer = builder.Configuration["BaseSetup:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["BaseSetup:SecretKey"]!))


        };
    });


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
