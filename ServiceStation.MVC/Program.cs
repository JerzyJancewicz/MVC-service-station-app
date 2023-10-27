using Microsoft.EntityFrameworkCore;
using ServiceStation.Infrastructure.Presistance;
using ServiceStation.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*
// Dodanie dbcontextu do pojemnika dependency Injection i dodanie do parametru connectionString ktory znajduje sie w pliku json
builder.Services.AddDbContext<ServiceStationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")));*/

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// jakiekolwiek zapytanie nie wyslane z protokolu https zostanie przekierowane na ten protokul
app.UseHttpsRedirection();
// umozliwia zwracanie plikow statycznych (css js) do klienta
app.UseStaticFiles();
// dodawanie routingu (umozliwia dodawanie sciezek do odpowiednich handlerow)
app.UseRouting();

app.UseAuthorization();

// definiuje w jaki sposob bedziemy chcieli obsluzyc zapytania od klienta.
// {controller=Home}/{action=Index}/{id?}. Domyslnym kontrolerem jest "Home" z akcja "Index" z opcjonalnym Id
// Klienta odnosi sie do sciezki i po stronie serwera zostanie ona dopasowana do odpowiedniego kontrolera.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
