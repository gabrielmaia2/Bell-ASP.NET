using Bell.Seller.Domain.Models;
using Bell.Seller.Services;

namespace Bell.Seller.Controllers;

public class ProductController
{
    private readonly ProductService service;

    public ProductController(ProductService service)
    {
        this.service = service;
    }

    public Product? Get(ulong id)
    {
        return service.Get(id);
    }

    public Product Publish(NewProduct product)
    {
        return service.Publish(product);
    }

    public Product Edit(Product product)
    {
        return service.Edit(product);
    }

    public Product Delete(ulong id)
    {
        return service.Delete(id);
    }
}
