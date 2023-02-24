using Bell.Core.Domain.Models;
using Bell.Customer.Services;
using Bell.Customer.ViewModels;

namespace Bell.Customer.Controllers;

public class ProductController
{
    private readonly ProductService service;

    public ProductController(ProductService service)
    {
        this.service = service;
    }

    public Page<ProductVM> Search(string search, uint pageIndex)
    {
        var oldPage = service.Search(search, pageIndex);
        return Page<ProductVM>.Clone(oldPage.Data.Select(p => new ProductVM(p)).ToList().AsReadOnly(), oldPage);
    }
}
