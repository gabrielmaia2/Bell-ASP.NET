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
    public static WebApplicationBuilder ConfigureDB(WebApplicationBuilder builder)
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

        return builder;
    }

    public static WebApplicationBuilder ConfigureRepositoryDependencies(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IProductRepository, ProductRepository>();

        return builder;
    }
}
