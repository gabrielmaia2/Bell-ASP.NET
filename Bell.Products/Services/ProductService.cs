using Bell.Products.Domain.Repositories;

namespace Bell.Products.Services;

public class ProductService
{
    private readonly IProductRepository repository;

    public ProductService(IProductRepository repository)
    {
        this.repository = repository;
    }
}