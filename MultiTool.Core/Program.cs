using MultiTool.Core.Providers;
using MultiTool.Core.Config;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddHttpClient();
services.AddScoped<IWeatherProvider, WeatherProvider>();
services.Configure<WeatherClientConfig>(builder.Configuration.GetSection("WeatherConfig"));
services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "MultiTool API", Version= "v1" });
});
services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }
        await next();
    });
}
app.UseCors();
app.MapGet("/Status", x => x.Response.WriteAsync("ALIVE"));
app.UseRouting();
app.MapControllers();
app.Run();
