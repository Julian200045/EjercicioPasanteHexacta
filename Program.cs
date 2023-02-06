using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EjercicioPasanteHexacta;
using EjercicioPasanteHexacta.Models;
using EjercicioPasanteHexacta.Services;

var AllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Servicios

builder.Services.AddControllersWithViews();

builder.Services.AddSqlServer<AppPersonasContext>(builder.Configuration.GetConnectionString("AppPersonasDbCs"));

builder.Services.AddScoped<IPersonaService, PersonaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:44462").
                          AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(AllowSpecificOrigins);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");


app.MapGet("/dbconexion", async ([FromServices] AppPersonasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Table created");

});

app.Run();


