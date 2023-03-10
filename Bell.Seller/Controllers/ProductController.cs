using Bell.Core.Domain.Models;
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

    /// <summary>
    /// Searches in all products owned by the current user.
    /// </summary>
    /// <param name="search">The string to search in product names and descriptions.</param>
    /// <param name="currentPage">The current page in the search.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <returns>The current page for this search.</returns>
    public async Task<Page<Product>> SearchOwnProductsAsync(string search, uint currentPage, uint pageSize, CancellationToken ct)
    {
        return await service.SearchOwnProductsAsync(search, currentPage, pageSize, ct);
    }

    /// <summary>
    /// Gets a product owned by the current user by its id.
    /// </summary>
    /// <param name="id">The id of the product to get.</param>
    /// <returns>The product with the specified id or null if it does not exist.</returns>
    public async Task<Product?> GetOwnProductAsync(ulong id, CancellationToken ct)
    {
        return await service.GetOwnProductAsync(id, ct);
    }

    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="product">The new product to add.</param>
    /// <returns>The product added to the database.</returns>
    public async Task<Product> PublishAsync(NewProduct product, CancellationToken ct)
    {
        return await service.PublishAsync(product, ct);
    }

    /// <summary>
    /// Updates the product specified by its id.
    /// </summary>
    /// <param name="product">The product with the updated values.</param>
    /// <returns>The product added to the database.</returns>
    /// <exception cref="NotFoundException">When there is no product with the id specified to update.</exception>
    public async Task<Product> EditAsync(UpdateProduct product, CancellationToken ct)
    {
        return await service.EditAsync(product, ct);
    }

    /// <summary>
    /// Deletes the product specified by its id.
    /// </summary>
    /// <param name="id">The id of the product to delete.</param>
    /// <returns>The product removed from the database.</returns>
    /// <exception cref="NotFoundException">When there is no product with the id specified to delete.</exception>
    public async Task<Product> DeleteAsync(ulong id, CancellationToken ct)
    {
        return await service.DeleteAsync(id, ct);
    }
}
