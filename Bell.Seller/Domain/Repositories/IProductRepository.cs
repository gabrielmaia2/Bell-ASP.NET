using Bell.Seller.Domain.Models;

namespace Bell.Seller.Domain.Repositories;

public interface IProductRepository
{
    Product? Get(uint id);

    bool Add(Product product);

    bool Update(Product product);

    bool Delete(uint id);
}
