namespace Bell.Seller.Domain.Models;

/// <summary>
/// This class is used to update the fields of a product. Only the non-null fields are updated.
/// </summary>
public class UpdateProduct
{
    public ulong? Id { get; init; } = null;

    public string? Name { get; init; } = null;

    public string? Description { get; init; } = null;

    public decimal? Price { get; init; } = null;

    public UpdateProduct() { }
}
