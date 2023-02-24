using Bell.Core.Domain.Models;
using Bell.Customer.Domain.Models;
using Bell.Customer.Domain.Repositories;

namespace Bell.Customer.Services;

public class ProductService
{
    private readonly IProductRepository repository;

    public uint PageSize { get; set; }

    public ProductService(IProductRepository repository)
    {
        this.repository = repository;
    }

    internal Page<Product> Search(string search, uint index)
    {
        return repository.GetSearch(search, index, PageSize);
    }
}
