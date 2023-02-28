namespace Bell.Seller.Domain.Models;

public class NewProduct
{
    public string Name { get; init; } = "";

    public string Description { get; init; } = "";

    public decimal Price { get; init; }

    public NewProduct() { }

    public NewProduct(Product product)
    {
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }
}
