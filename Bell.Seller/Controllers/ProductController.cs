using Bell.Core.Domain.Models;
using Bell.Seller.Domain.Models;
using Bell.Seller.Services;

namespace Bell.Seller.Controllers;

public class ProductController
{
    private readonly ProductService service;

    public ProductController(ProductService service)
    {
        this.service = service;
    }

    public async Task<Page<Product>> SearchOwnProductsAsync(string search, uint currentPage, uint pageSize, CancellationToken ct)
    {
        return await service.SearchOwnProductsAsync(search, currentPage, pageSize, ct);
    }

    public async Task<Product?> GetOwnProductAsync(ulong id, CancellationToken ct)
    {
        return await service.GetOwnProductAsync(id, ct);
    }

    public async Task<Product> PublishAsync(NewProduct product, CancellationToken ct)
    {
        return await service.PublishAsync(product, ct);
    }

    public async Task<Product> EditAsync(UpdateProduct product, CancellationToken ct)
    {
        return await service.EditAsync(product, ct);
    }

    public async Task<Product> DeleteAsync(ulong id, CancellationToken ct)
    {
        return await service.DeleteAsync(id, ct);
    }
}
