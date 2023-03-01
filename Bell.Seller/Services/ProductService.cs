using Bell.Seller.Domain.Models;
using Bell.Seller.Domain.Repositories;

namespace Bell.Seller.Services;

public class ProductService
{
    private readonly IProductRepository repository;

    public uint PageSize { get; set; }

    public ProductService(IProductRepository repository)
    {
        this.repository = repository;
    }

    public Product? GetOwnProduct(ulong id)
    {
        return repository.GetOwnProduct(id);
    }

    public Product Publish(NewProduct product)
    {
        return repository.Add(product);
    }

    public Product Edit(Product product)
    {
        return repository.Update(product);
    }

    public Product Delete(ulong id)
    {
        return repository.Delete(id);
    }
}
