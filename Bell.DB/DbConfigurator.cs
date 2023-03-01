using Bell.DB.Data;
using Bell.DB.Repositories;
using Bell.Seller.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bell.DB;

public static class DbConfigurator
{
    public static void ConfigureBuilderDB(WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDbContext<BellContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("BellContext") ?? throw new InvalidOperationException("Connection string 'BellContext' not found.")));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        }
        else
        {
            builder.Services.AddDbContext<BellContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BellContext") ?? throw new InvalidOperationException("Connection string 'BellContext' not found.")));
        }
    }

    public static void ConfigureRepositoryDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
    }

    public static void ConfigureAppDB(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            // NOTE Comes from Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.
            // That NuGet package provides middleware for EF Core error pages to detect and diagnose errors with migrations.
            app.UseMigrationsEndPoint();
        }

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<BellContext>();

            // Ensures database is created if does not exist
            context.Database.EnsureCreated();

            if (app.Environment.IsDevelopment())
            {
                // Initializes database with dummy data when in development.
                DbInitializer.Initialize(context);
            }
        }
    }
}
