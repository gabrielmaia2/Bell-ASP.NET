using System.ComponentModel.DataAnnotations;
using NewProductModel = Bell.Seller.Domain.Models.NewProduct;

namespace Bell.Web.Seller.Models;

public class NewProduct
{
    public string Name { get; init; } = "";

    [Required(AllowEmptyStrings = true)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Description { get; init; } = "";

    public decimal Price { get; init; }

    public NewProductModel AsModel()
    {
        return new NewProductModel()
        {
            Name = this.Name,
            Description = this.Description,
            Price = this.Price
        };
    }
}
