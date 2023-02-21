using Bell.Core.Domain.Models;
using Bell.Products.Domain.Models;
using Bell.Products.Domain.Repositories;

namespace Bell.Products.Specs.Mocks;

public class ProductRepositoryMock : IProductRepository
{
    private readonly List<ProductModel> products;

    public ProductRepositoryMock(List<ProductModel> products)
    {
        this.products = products;
    }

    public bool Add(ProductModel product)
    {
        products.Add(product);
        return true;
    }

    public bool Delete(uint id)
    {
        products.RemoveAll(p => p.Id == id);
        return true;
    }

    public ProductModel? Get(uint id)
    {
        return products.Find(p => p.Id == id);
    }

    public PagerPage<ProductModel> GetPage(int pageIndex, uint pageSize)
    {
        throw new NotImplementedException();
    }

    public bool Update(ProductModel product)
    {
        var index = products.FindIndex(p => p.Id == product.Id);
        products.Insert(index, product);
        products.RemoveAt(index + 1);
        return true;
    }
}
