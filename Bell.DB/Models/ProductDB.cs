using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bell.Seller.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bell.DB.Models;

// Primary keys naming conventions: PK_<type name>.
public class ProductDB
{
    [Key]
    [Column("id", Order = 0)]
    public ulong Id { get; set; }

    [MaxLength(200)]
    [Unicode(true)]
    [Column("name", Order = 1)]
    public string Name { get; set; } = "";

    [MaxLength(5000)]
    [Unicode(true)]
    [Column("description", Order = 2)]
    [Required(AllowEmptyStrings = true)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Description { get; set; } = "";

    [Precision(10, 2)]
    [Column("price", Order = 3)]
    public decimal Price { get; set; }

    public ProductDB() { }

    public ProductDB(NewProduct product) : this(new Product(product)) { }

    public ProductDB(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }

    public Product AsProduct()
    {
        return new Product()
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Price = this.Price,
        };
    }

    public void SetFrom(UpdateProduct product)
    {
        if (product.Id != null)
            Id = (ulong)product.Id;
        if (product.Name != null)
            Name = product.Name;
        if (product.Description != null)
            Description = product.Description;
        if (product.Price != null)
            Price = (decimal)product.Price;
    }
}
