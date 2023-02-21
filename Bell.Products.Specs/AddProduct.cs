using Bell.Products.Controllers;
using Bell.Products.Domain.Models;
using Bell.Products.Domain.Repositories;
using Bell.Products.Services;
using Bell.Products.Specs.Mocks;

namespace Bell.Products.Specs;

public class AddProduct
{
    IProductRepository repository;

    ProductService service;

    ProductController controller;

    public AddProduct()
    {
        repository = new ProductRepositoryMock(new List<ProductModel>());
        service = new ProductService(repository);
        controller = new(service);
    }

    [Fact]
    public void Test1()
    {

    }
}
