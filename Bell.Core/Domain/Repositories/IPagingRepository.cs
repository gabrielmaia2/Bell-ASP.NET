using Bell.Core.Domain.Models;

namespace Bell.Core.Domain.Repositories;

public interface IPagingRepository<T>
{
    /// <summary>
    /// Gets all the items by splitting the content in pages and getting the page by its index.
    /// </summary>
    /// <param name="pageIndex">The index of the page to get.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <returns></returns>
    Page<T> GetAllPaging(int pageIndex, uint pageSize);
}
