using Microsoft.EntityFrameworkCore;

namespace Chirp.Razor;

using Chirp.SQLite;

public class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Load database connection via configuration
        string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<CheepDBContext>(options => options.UseSqlite(connectionString));

// Add services to the container.
        builder.Services.AddRazorPages();
        var dbPath = Environment.GetEnvironmentVariable("CHIRPDBPATH") ?? Path.GetTempPath() + "chirp.db";
        DBFacade.SetDBPath(dbPath);
        builder.Services.AddSingleton<ICheepService, CheepService>();


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

        app.MapRazorPages();

        app.Run();
    }
}

