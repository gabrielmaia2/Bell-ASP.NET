using Bell.Core.Domain.Exceptions;
using Bell.Core.Domain.Models;
using Bell.DB.Data;
using Bell.DB.Models;
using Bell.Seller.Domain.Models;
using Bell.Seller.Domain.Repositories;

namespace Bell.DB.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly BellContext context;

    public ProductRepository(BellContext context)
    {
        this.context = context;
    }

    public Product? Get(ulong id)
    {
        return context.Products.Find(id)?.AsProduct().Copy();
    }

    public Product Add(NewProduct product)
    {
        var entity = context.Products.Add(new ProductDB(product)).Entity;
        context.SaveChanges();
        return entity.AsProduct();
    }

    public Product Update(Product product)
    {
        var entity = context.Products.Find(product.Id);

        if (entity == null) throw new NotFoundException("Product");

        entity.SetFrom(product);
        context.SaveChanges();
        return entity.AsProduct();
    }

    public Product Delete(ulong id)
    {
        var entity = context.Products.Find(id);

        if (entity == null) throw new NotFoundException("Product");

        var res = entity.AsProduct();
        context.Products.Remove(entity);
        context.SaveChanges();

        return res;
    }

    // public PagerPage<Product> GetPage(int pageIndex, uint pageSize)
    // {
    //     throw new NotImplementedException();
    // }
}
