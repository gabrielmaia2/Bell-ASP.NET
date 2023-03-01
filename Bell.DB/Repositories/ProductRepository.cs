using Bell.Core.Domain.Models;
using Bell.DB.Data;
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
        throw new NotImplementedException();
    }

    public Product Add(NewProduct product)
    {
        throw new NotImplementedException();
    }

    public Product Update(Product product)
    {
        throw new NotImplementedException();
    }

    public Product Delete(ulong id)
    {
        throw new NotImplementedException();
    }

    // public PagerPage<Product> GetPage(int pageIndex, uint pageSize)
    // {
    //     throw new NotImplementedException();
    // }
}
