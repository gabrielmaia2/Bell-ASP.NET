using Bell.Core.Domain.Models;
using Bell.Seller.Services;
using Bell.Seller.ViewModels;

namespace Bell.Seller.Controllers;

public class ProductController
{
    private readonly ProductService service;

    public ProductController(ProductService service)
    {
        this.service = service;
    }
}
