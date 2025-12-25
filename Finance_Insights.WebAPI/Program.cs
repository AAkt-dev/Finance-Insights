using Finance_Insights.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
//Asra starting the project
//Trying again
// Add services to the container.
builder.Services.ConfigureCORS();
builder.Services.ConfigureIISIntegrations();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.Configure<ApiBehaviorOptions>(
    options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    }
);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddApplicationPart(typeof().Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
