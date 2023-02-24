using System.Collections.Generic;
using Bell.Core.Domain.Repositories;
using Bell.Seller.Domain.Models;

namespace Bell.Seller.Domain.Repositories;

public interface IProductRepository : IPager<Product>
{
    Product? Get(uint id);

    bool Add(Product product);

    bool Update(Product product);

    bool Delete(uint id);
}
