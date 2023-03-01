using Bell.DB;
using Bell.Seller.Controllers;
using Bell.Seller.Services;

void ConfigureDependencies(WebApplicationBuilder builder)
{
    DbConfigurator.ConfigureRepositoryDependencies(builder);

    builder.Services.AddScoped<ProductService>();
    builder.Services.AddScoped<ProductController>();
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

ConfigureDependencies(builder);

DbConfigurator.ConfigureBuilderDB(builder);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // Configure the HTTP request pipeline.
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseExceptionHandler("/Error")
        .UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

DbConfigurator.ConfigureAppDB(app);

app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthorization();

app.MapRazorPages();

app.Run();
