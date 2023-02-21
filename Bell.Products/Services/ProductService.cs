using Bell.Core.Domain.Models;
using Bell.Products.Domain.Models;
using Bell.Products.Domain.Repositories;

namespace Bell.Products.Services;

public class ProductService
{
    private readonly IProductRepository repository;

    public uint PageSize { get; set; }

    public ProductService(IProductRepository repository)
    {
        this.repository = repository;
    }

    internal PagerPage<ProductModel> Search(string search, uint index)
    {
        return repository.GetPage((int)index, PageSize);
    }
}
