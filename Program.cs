using MealMatch.Data;
using MealMatch.Model_Services;
using Microsoft.EntityFrameworkCore;

// De builder gebruik je om de applicatie in te stellen
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Razor Pages aanzetten
builder.Services.AddRazorPages();

// Verbinding met SQL Server (de connection string staat in appsettings.json)
builder.Services.AddDbContext<MealMatchDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MealMatchConnection")
    ));

// Service voor het opslaan en ophalen van recepten
builder.Services.AddScoped<ReceptService>();

// Na deze regel kun je geen services meer toevoegen
WebApplication app = builder.Build();

// Foutpagina en beveiliging voor als de website online staat
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Start de website
app.Run();