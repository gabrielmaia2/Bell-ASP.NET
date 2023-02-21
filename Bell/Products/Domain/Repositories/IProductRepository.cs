using System.Collections.Generic;
using Bell.Core.Domain.Repositories;
using Bell.Products.Domain.Models;

namespace Bell.Products.Domain.Repositories;

public interface IProductRepository : IPagingRepository<Product>
{
    Product? Get(uint id);

    bool Add(Product product);

    bool Update(Product product);

    bool Delete(uint id);
}
