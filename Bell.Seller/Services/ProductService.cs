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

    public async Task<Page<Product>> SearchOwnProductsAsync(string search, uint currentPage, uint pageSize, CancellationToken ct)
    {
        return await repository.SearchOwnProductsAsync(search, currentPage, pageSize, ct);
    }

    public async Task<Product?> GetOwnProductAsync(ulong id, CancellationToken ct)
    {
        return await repository.GetOwnProductAsync(id, ct);
    }

    public async Task<Product> PublishAsync(NewProduct product, CancellationToken ct)
    {
        return await repository.AddAsync(product, ct);
    }

    public async Task<Product> EditAsync(UpdateProduct product, CancellationToken ct)
    {
        return await repository.UpdateAsync(product, ct);
    }

    public async Task<Product> DeleteAsync(ulong id, CancellationToken ct)
    {
        return await repository.DeleteAsync(id, ct);
    }
}
