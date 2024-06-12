using Microsoft.EntityFrameworkCore;
using VotingSystem.DataAccess.DataContext;
using VotingSystem.DataAccess.Interfaces;
using VotingSystem.DataAccess.Repository;
using VotingSystem.DataAccess.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VotingSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VotingSystem"));
});
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddTransient<DatabaseModelValidator>();
builder.Services.AddTransient<IUserProfileRepository, UserProfileRepository>();
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
