namespace Bell.Products.ViewModels;

public class ProductVM
{
    public uint Id { get; init; }

    public string Name { get; init; } = "";

    public string Description { get; init; } = "";

    public decimal Price { get; init; }
}