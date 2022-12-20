using AppKi.Data;
using Flour.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLogging();


builder.Services.AddRazorPages().Services
    .AddServerSideBlazor().Services
    .AddSingleton<WeatherForecastService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();