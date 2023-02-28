using Bell.Core.Domain.Models;
using Bell.Seller.Domain.Models;
using Bell.Seller.Domain.Repositories;

namespace Bell.DB.Repositories;

public class ProductRepository : IProductRepository
{
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
