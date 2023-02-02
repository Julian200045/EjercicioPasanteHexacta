using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EjercicioPasanteHexacta;
using EjercicioPasante.Models;
using System.Formats.Tar;
using EjercicioPasanteHexacta.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios

builder.Services.AddControllersWithViews();

builder.Services.AddSqlServer<AppPersonasContext>(builder.Configuration.GetConnectionString("AppPersonasDbCs"));

builder.Services.AddScoped<IPersonaService, PersonaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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
    return Results.Ok("Table created");

});


app.MapGet("/prueba", async ([FromServices] AppPersonasContext dbContext) =>
{
    return Results.Ok("CASE " + "ELSE Otro END;");
});





app.Run();


