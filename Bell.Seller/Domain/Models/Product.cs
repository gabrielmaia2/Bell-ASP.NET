namespace Bell.Seller.Domain.Models;

public class Product
{
    public uint Id { get; init; }

    public string Name { get; init; } = "";

    public string Description { get; init; } = "";

    public decimal Price { get; init; }
}
