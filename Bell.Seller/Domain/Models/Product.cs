namespace Bell.Seller.Domain.Models;

public class Product
{
    public ulong Id { get; init; }

    public string Name { get; init; } = "";

    public string Description { get; init; } = "";

    public decimal Price { get; init; }

    public Product() { }


    public Product(NewProduct product)
    {
        Id = 0;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }
}
