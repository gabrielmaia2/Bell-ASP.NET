using System.ComponentModel.DataAnnotations;
using Bell.Seller.Domain.Models;
using ProductModel = Bell.Seller.Domain.Models.Product;

namespace Bell.Web.Seller.Models;

public class Product
{
    public ulong Id { get; set; }

    public string Name { get; set; } = "";

    [Required(AllowEmptyStrings = true)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Description { get; set; } = "";

    public decimal Price { get; set; }

    public Product() : this(new ProductModel()) { }

    public Product(ProductModel product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }

    public ProductModel AsProduct()
    {
        return new ProductModel()
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Price = this.Price
        };
    }

    public UpdateProduct AsUpdateProduct()
    {
        return new UpdateProduct()
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Price = this.Price
        };
    }
}
