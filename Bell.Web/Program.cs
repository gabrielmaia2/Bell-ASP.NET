using Bell.DB;
using Bell.Seller.Controllers;
using Bell.Seller.Services;

void ConfigureDependencies(WebApplicationBuilder builder)
{
    DbConfigurator.ConfigureRepositoryDependencies(builder);

    builder.Services.AddSingleton<ProductService>();
    builder.Services.AddSingleton<ProductController>();
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

ConfigureDependencies(builder);

DbConfigurator.ConfigureDB(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseExceptionHandler("/Error")
        .UseHsts();
}

app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthorization();

app.MapRazorPages();

app.Run();
