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
    public ulong Id { get; init; }

    [MaxLength(200)]
    [Unicode(true)]
    [Column("name", Order = 1)]
    public string Name { get; init; } = "";

    [MaxLength(5000)]
    [Unicode(true)]
    [Column("description", Order = 2)]
    [Required(AllowEmptyStrings = true)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Description { get; init; } = "";

    [Precision(10, 2)]
    [Column("price", Order = 3)]
    public decimal Price { get; init; }

    public ProductDB(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }
}
