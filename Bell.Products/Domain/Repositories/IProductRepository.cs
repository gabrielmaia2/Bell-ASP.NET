using System.Collections.Generic;
using Bell.Core.Domain.Repositories;
using Bell.Products.Domain.Models;

namespace Bell.Products.Domain.Repositories;

public interface IProductRepository : IPager<ProductModel>
{
    ProductModel? Get(uint id);

    bool Add(ProductModel product);

    bool Update(ProductModel product);

    bool Delete(uint id);
}
