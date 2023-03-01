using Bell.DB.Models;

namespace Bell.DB.Data;

public static class DbInitializer
{
    public static void Initialize(BellContext context)
    {
        // Look for any students.
        if (context.Products.Any())
        {
            return;
        }

        var products = new ProductDB[]
        {
            new ProductDB { Name = "Product 1", Description = "Description 1", Price = 10.00m },
            new ProductDB { Name = "Product 2", Description = "Description 2", Price = 268.00m },
            new ProductDB { Name = "Another product", Description = "Description 3", Price = 23.50m },
            new ProductDB { Name = "Papaya", Description = "Just a papaya #yum パパや", Price = 2353.55m },
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
