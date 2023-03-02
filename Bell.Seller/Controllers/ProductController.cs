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

    public async Task<Page<Product>> SearchOwnProducts(string search, uint currentPage, uint pageSize, CancellationToken ct)
    {
        return await service.SearchOwnProducts(search, currentPage, pageSize, ct);
    }

    public async Task<Product?> GetOwnProduct(ulong id, CancellationToken ct)
    {
        return await service.GetOwnProduct(id, ct);
    }

    public async Task<Product> Publish(NewProduct product, CancellationToken ct)
    {
        return await service.Publish(product, ct);
    }

    public async Task<Product> Edit(Product product, CancellationToken ct)
    {
        return await service.Edit(product, ct);
    }

    public async Task<Product> Delete(ulong id, CancellationToken ct)
    {
        return await service.Delete(id, ct);
    }
}
