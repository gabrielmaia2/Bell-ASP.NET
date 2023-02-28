using Bell.Seller.Domain.Models;

namespace Bell.Seller.Domain.Repositories;

public interface IProductRepository
{
    Product? Get(ulong id);

    Product Add(NewProduct product);

    Product Update(Product product);

    Product Delete(ulong id);
}
