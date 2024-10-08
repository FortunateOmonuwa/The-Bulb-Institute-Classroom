using CompanyEmployeesEbook.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

//Add Logger
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.Use(async (context, next) =>
{
    Console.WriteLine($"Logic before executing the next delegtae in the use method");
    await next();
    Console.WriteLine($"Logics after executing the next delegate in the use method");
});

app.Map("/usingmapbranch", builder =>
{
    builder.Use(async (context, next) =>
    {
        Console.WriteLine("Map branch logic in the use method before the next delegate");
        await next();
        Console.WriteLine("Map branch logic in the use method after the next delegate");

    });
    builder.Run(async context =>
    {
        Console.WriteLine($"Map branch response to the client in the run method");
        await context.Response.WriteAsync("Hello from the map branch");

    });
});

app.MapWhen(context => context.Request.Query.ContainsKey("testingquerystring"), builder =>
{
    builder.Run(async context =>
    {
        await context.Response.WriteAsync("Hello from the Mapwhen branch");
    });
});


app.Run(async context =>
{
    Console.WriteLine($"Writing the response to the client in the run method");
    await context.Response.WriteAsync("Hello from the middleware component");
});

app.MapControllers();

app.Run();
