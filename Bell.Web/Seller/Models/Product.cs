using System.ComponentModel.DataAnnotations;
using ProductModel = Bell.Seller.Domain.Models.Product;

namespace Bell.Web.Seller.Models;

public class Product
{
    public ulong Id { get; init; }

    public string Name { get; init; } = "";

    [Required(AllowEmptyStrings = true)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Description { get; init; } = "";

    public decimal Price { get; init; }

    public Product() : this(new ProductModel()) { }

    public Product(ProductModel product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }

    public ProductModel AsModel()
    {
        return new ProductModel()
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Price = this.Price
        };
    }
}
