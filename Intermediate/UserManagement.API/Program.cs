using UserManagement.API.DataAccess.DataContext;

using Microsoft.EntityFrameworkCore;
using UserManagement.API;
using UserManagement.API.Service;
using UserManagement.API.DataAccess.Interfaces;
using UserManagement.API.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<IUserService, UserRepository > ();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //cookie based authentication
    //OAuth/Open ID authentication
    //JWT Authentication
    .AddJwtBearer(options =>
    {
        //options.SaveToken = true;
        options.RequireHttpsMetadata = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
          //  ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
          //  ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidIssuer = builder.Configuration.GetSection("AppSettings:Issuer").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( builder.Configuration["AppSettings:Secret"]))
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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
