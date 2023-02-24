using Bell.Core.Domain.Models;
using Bell.Seller.Domain.Models;
using Bell.Seller.Domain.Repositories;

namespace Bell.Seller.Specs.Mocks;

public class ProductRepositoryMock : IProductRepository
{
    private readonly List<Product> products;

    public ProductRepositoryMock(List<Product> products)
    {
        this.products = products;
    }

    public bool Add(Product product)
    {
        products.Add(product);
        return true;
    }

    public bool Delete(uint id)
    {
        products.RemoveAll(p => p.Id == id);
        return true;
    }

    public Product? Get(uint id)
    {
        return products.Find(p => p.Id == id);
    }

    public PagerPage<Product> GetPage(int pageIndex, uint pageSize)
    {
        throw new NotImplementedException();
    }

    public bool Update(Product product)
    {
        var index = products.FindIndex(p => p.Id == product.Id);
        products.Insert(index, product);
        products.RemoveAt(index + 1);
        return true;
    }
}
