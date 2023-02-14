using MultiTool.Core.Providers;
using MultiTool.Models.Weather;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddHttpClient();
services.AddScoped<IWeatherProvider, WeatherProvider>();
services.Configure<WeatherClientConfig>(builder.Configuration.GetSection("WeatherConfig"));

var app = builder.Build();
app.MapGet("/Status", x => x.Response.WriteAsync("ALIVE"));
app.UseRouting();
app.MapControllers();
app.Run();
