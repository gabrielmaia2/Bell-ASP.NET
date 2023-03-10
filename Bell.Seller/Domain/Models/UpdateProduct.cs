namespace Bell.Seller.Domain.Models;

/// <summary>
/// This class is used to update the fields of a product. Only the non-null fields are updated.
/// </summary>
public class UpdateProduct
{
    public ulong Id { get; set; }

    public string? Name { get; set; } = null;

    public string? Description { get; set; } = null;

    public decimal? Price { get; set; } = null;

    public UpdateProduct() { }
}
