using Bell.Products.Domain.Models;

namespace Bell.Products.ViewModels;

public class ProductVM
{
    public uint Id { get; init; }

    public string Name { get; init; } = "";

    public string Description { get; init; } = "";

    public decimal Price { get; init; }

    public ProductVM(ProductModel product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }
}
