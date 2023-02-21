using System.Collections.Generic;
using Bell.Products.Domain.Models;

namespace Bell.Products.Domain.Repositories;

public interface IProductRepository
{
    IReadOnlyCollection<Product> GetAll();

    IReadOnlyCollection<Product> GetAllPaging(uint page);

    Product? Get(uint id);

    bool Add(Product product);

    bool Update(Product product);

    bool Delet(uint id);
}
