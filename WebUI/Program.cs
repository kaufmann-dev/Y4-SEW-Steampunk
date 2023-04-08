using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;


var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<SteamDbContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(8,0,26))
    )
);
builder.Services.AddScoped<IAirshipRepository, AirshipRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();