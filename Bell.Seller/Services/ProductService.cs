using Bell.Core.Domain.Models;
using Bell.Seller.Domain.Models;
using Bell.Seller.Domain.Repositories;

namespace Bell.Seller.Services;

public class ProductService
{
    private readonly IProductRepository repository;

    public ProductService(IProductRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Page<Product>> SearchOwnProducts(string search, uint currentPage, uint pageSize, CancellationToken ct)
    {
        return await repository.SearchOwnProducts(search, currentPage, pageSize, ct);
    }

    public async Task<Product?> GetOwnProduct(ulong id, CancellationToken ct)
    {
        return await repository.GetOwnProduct(id, ct);
    }

    public async Task<Product> Publish(NewProduct product, CancellationToken ct)
    {
        return await repository.Add(product, ct);
    }

    public async Task<Product> Edit(UpdateProduct product, CancellationToken ct)
    {
        return await repository.Update(product, ct);
    }

    public async Task<Product> Delete(ulong id, CancellationToken ct)
    {
        return await repository.Delete(id, ct);
    }
}
