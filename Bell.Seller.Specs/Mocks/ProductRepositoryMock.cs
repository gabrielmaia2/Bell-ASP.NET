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

    public Product Add(NewProduct product)
    {
        products.Add(new Product(product));
        return new Product(product);
    }

    public Product Delete(ulong id)
    {
        var i = products.FindIndex(p => p.Id == id);
        var product = products[i];
        products.RemoveAt(i);
        return product;
    }

    public Product? GetOwnProduct(ulong id)
    {
        return products.Find(p => p.Id == id);
    }

    public Product Update(Product product)
    {
        var index = products.FindIndex(p => p.Id == product.Id);
        products.Insert(index, product);
        products.RemoveAt(index + 1);
        return product;
    }
}
