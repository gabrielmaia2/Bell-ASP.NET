using Bell.Seller.Domain.Models;
using Bell.Core.Domain.Exceptions;
using Bell.Core.Domain.Models;

namespace Bell.Seller.Domain.Repositories;

public interface IProductRepository
{
    /// <summary>
    /// Searches in all products owned by the current user.
    /// </summary>
    /// <param name="search">The string to search in product names and descriptions.</param>
    /// <param name="currentPage">The current page in the search.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <returns>The current page for this search.</returns>
    public Page<Product> SearchOwnProducts(string search, uint currentPage, uint pageSize);

    /// <summary>
    /// Gets a product owned by the current user by its id.
    /// </summary>
    /// <param name="id">The id of the product to get.</param>
    /// <returns>The product with the specified id or null if it does not exist.</returns>
    Product? GetOwnProduct(ulong id);

    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="product">The new product to add.</param>
    /// <returns>The product added to the database.</returns>
    Product Add(NewProduct product);

    /// <summary>
    /// Updates the product specified by its id.
    /// </summary>
    /// <param name="product">The product with the updated values.</param>
    /// <returns>The product added to the database.</returns>
    /// <exception cref="NotFoundException">When there is no product with the id specified to update.</exception>
    Product Update(Product product);

    /// <summary>
    /// Deletes the product specified by its id.
    /// </summary>
    /// <param name="id">The id of the product to delete.</param>
    /// <returns>The product removed from the database.</returns>
    /// <exception cref="NotFoundException">When there is no product with the id specified to delete.</exception>
    Product Delete(ulong id);
}
