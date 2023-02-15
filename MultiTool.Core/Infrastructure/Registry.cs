using Microsoft.OpenApi.Models;
using MultiTool.Core.Config;
using MultiTool.Core.Providers;

namespace MultiTool.Core.Infrastructure
{
    public static class Registry
    {
        public static void RegisterCoreServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.AddScoped<IWeatherProvider, WeatherProvider>();
            services.AddScoped<ICalculationProvider, CalculationProvider>();
            services.Configure<WeatherClientConfig>(config.GetSection("WeatherConfig"));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(config.GetSection("FrontendUrl").Value)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "MultiTool API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Program).Assembly);
        }

        public static void RegisterSwagger(this WebApplication app)
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
    }
}
