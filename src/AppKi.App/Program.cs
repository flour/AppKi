using AppKi.Business;
using AppKi.Business.Hubs;
using Flour.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();

// Add services to the container.

builder.Services
    .AddControllers().Services
    .AddBusiness(builder.Configuration);

var app = builder.Build();

app.UseRouting()
    .UseHttpsRedirection()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapHub<PublicHub>("ws/public");
        endpoints.MapControllers();
    });

app.Run();