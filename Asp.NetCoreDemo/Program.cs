using Asp.NetCoreDemo.Models;
using Asp.NetCoreDemo.Models.Interfaces;
using Asp.NetCoreDemo.Models.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(services =>
{
    services.TryAddScoped<IScoped, SampleClass>();
    services.TryAddSingleton<ISingleton, SampleClass>();
    services.TryAddTransient<ITransient, SampleClass>();
    services.TryAddTransient<SampleService, SampleService>();
    services.AddControllers();
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
