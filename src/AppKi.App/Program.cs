using AppKi.Business;
using Flour.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();

// Add services to the container.

builder.Services
    .AddControllers().Services
    .AddBusiness(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();