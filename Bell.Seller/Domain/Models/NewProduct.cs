namespace Bell.Seller.Domain.Models;

public class NewProduct
{
    public string Name { get; set; } = "";

    public string Description { get; set; } = "";

    public decimal Price { get; set; }

    public NewProduct() { }

    public NewProduct(Product product)
    {
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }
}
