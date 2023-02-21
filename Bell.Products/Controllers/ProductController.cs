using Bell.Core.Domain.Models;
using Bell.Products.Services;
using Bell.Products.ViewModels;

namespace Bell.Products.Controllers;

public class ProductController
{
    private readonly ProductService service;

    public ProductController(ProductService service)
    {
        this.service = service;
    }

    public PagerPage<ProductVM> Search(string search, uint pageIndex)
    {
        var oldPage = service.Search(search, pageIndex);
        return PagerPage<ProductVM>.Clone(oldPage.Data.Select(p => new ProductVM(p)).ToList().AsReadOnly(), oldPage);
    }
}
