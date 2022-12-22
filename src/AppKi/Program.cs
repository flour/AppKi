using AppKi.Business;
using Flour.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLogging();

builder.Services
    .AddRazorPages().Services
    .AddServerSideBlazor().Services
    .AddAntDesign()
    .AddBusiness(builder.Configuration);

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