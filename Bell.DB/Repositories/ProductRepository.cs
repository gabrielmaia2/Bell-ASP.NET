using Bell.Core.Domain.Exceptions;
using Bell.Core.Domain.Models;
using Bell.DB.Data;
using Bell.DB.Models;
using Bell.Seller.Domain.Models;
using Bell.Seller.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bell.DB.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly BellContext context;

    public ProductRepository(BellContext context)
    {
        this.context = context;
    }

    public async Task<Page<Product>> SearchOwnProductsAsync(string search, uint currentPage, uint pageSize, CancellationToken ct)
    {
        var res = context.Products
            .Where(p => EF.Functions.Like(p.Name, $"{search}%"))
            .OrderBy(p => p.Id)
            .Skip((int)(currentPage * pageSize))
            .Take((int)pageSize)
            .Select(p => p.AsProduct());

        var content = await res.ToListAsync(ct);
        return new Page<Product>(content.AsReadOnly(), currentPage, pageSize, (uint)content.Count());
    }

    public async Task<Product?> GetOwnProductAsync(ulong id, CancellationToken ct)
    {
        var productDB = await context.Products.FindAsync(id, ct);
        return productDB?.AsProduct().Copy();
    }

    public async Task<Product> AddAsync(NewProduct product, CancellationToken ct)
    {
        var entity = await context.Products.AddAsync(new ProductDB(product), ct);
        var productDB = entity.Entity;
        await context.SaveChangesAsync(ct);
        return productDB.AsProduct();
    }

    public async Task<Product> UpdateAsync(UpdateProduct product, CancellationToken ct)
    {
        var entity = await context.Products.FindAsync(product.Id, ct);

        if (entity == null) throw new NotFoundException("Product");

        entity.SetFrom(product);
        await context.SaveChangesAsync(ct);
        return entity.AsProduct();
    }

    public async Task<Product> DeleteAsync(ulong id, CancellationToken ct)
    {
        var entity = await context.Products.FindAsync(id, ct);

        if (entity == null) throw new NotFoundException("Product");

        var res = entity.AsProduct();
        context.Products.Remove(entity);
        await context.SaveChangesAsync(ct);

        return res;
    }
}
