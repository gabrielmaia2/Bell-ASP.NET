using Bell.Seller.Controllers;
using Bell.Seller.Domain.Models;
using Bell.Seller.Domain.Repositories;
using Bell.Seller.Services;
using Bell.Seller.Specs.Mocks;

namespace Bell.Seller.Specs;

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
