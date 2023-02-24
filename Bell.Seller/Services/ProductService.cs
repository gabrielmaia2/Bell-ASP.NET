using Bell.Core.Domain.Models;
using Bell.Seller.Domain.Models;
using Bell.Seller.Domain.Repositories;

namespace Bell.Seller.Services;

public class ProductService
{
    private readonly IProductRepository repository;

    public uint PageSize { get; set; }

    public ProductService(IProductRepository repository)
    {
        this.repository = repository;
    }
}
