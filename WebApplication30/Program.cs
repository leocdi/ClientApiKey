using Microsoft.Extensions.Configuration;
using NLog.Web;
using System.Net.Http;
using WebApplication30;
using WebClientApiKey;

var builder = WebApplication.CreateBuilder(args);

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<IswaggerClient, swaggerClient>(client =>
{
    var headerName = "X-Api-Key";
    var headerValue = builder.Configuration.GetValue<string>("ApiKey");

    client.DefaultRequestHeaders.Add(headerName, headerValue);
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseEndpoint"));
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
