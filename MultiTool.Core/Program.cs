using Serilog;
using MultiTool.Core.Infrastructure;

Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("MultiTool.Core.log",rollingInterval:RollingInterval.Day)
                .MinimumLevel.Information()
                .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.RegisterCoreServices(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.RegisterSwagger();
}
app.UseCors();
app.MapGet("/Status", x => x.Response.WriteAsync("ALIVE"));
app.UseRouting();
app.MapControllers();
app.Run();
