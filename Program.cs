using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EjercicioPasanteHexacta;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSqlServer<AppPersonasContext>(builder.Configuration.GetConnectionString("AppPersonasDbCs"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.MapGet("/dbconexion", async ([FromServices] AppPersonasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database created");

});

app.MapGet("/api/personas", async ([FromServices] AppPersonasContext dbContext) =>
{

});

app.Run();


