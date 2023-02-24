using Bell.Core.Domain.Models;
using Bell.Customer.Domain.Models;

namespace Bell.Customer.Domain.Repositories;

public interface IProductRepository
{
    Page<Product> GetSearch(string search, uint page, uint pageSize);
}
