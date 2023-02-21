namespace Bell.Core.Domain.Models;

public class Page<T>
{
    public IReadOnlyCollection<T> Data { get; init; }

    /// <summary>
    /// Gets the index of the current page.
    /// </summary>
    public PageIndex PageIndex { get; init; }

    /// <summary>
    /// Gets the maximum number of items per page. Default is 25.
    /// </summary>
    public uint PageSize { get; init; } = 25;

    /// <summary>
    /// Gets the total number of items in the search. Is null if not set.
    /// </summary>
    public ulong? TotalItems { get; init; } = null;

    /// <summary>
    /// Gets the page number of the page with index zero. Default is 1.
    /// </summary>
    public int PageNumberIndexZero { get; init; } = 1;

    /// <summary>
    /// Gets the number of the current page.
    /// </summary>
    public int CurrentPage => PageIndex.CurrentIndex + PageNumberIndexZero;

    /// <summary>
    /// Gets the number of the last page.
    /// </summary>
    public int LastPage => PageIndex.LastIndex + PageNumberIndexZero;

    /// <summary>
    /// Gets the number of the first page.
    /// </summary>
    public int FirstPage => PageIndex.FirstIndex + PageNumberIndexZero;

    /// <summary>
    /// Determines whether there is a previous page.
    /// </summary>
    public bool HasPrevious => PageIndex.HasPrevious;

    /// <summary>
    /// Determines whether there is a next page.
    /// </summary>
    public bool HasNext => PageIndex.HasNext;

    /// <summary>
    /// Gets the number of the previous page.
    /// </summary>
    public int? PreviousPage => PageIndex.PreviousIndex + PageNumberIndexZero;

    /// <summary>
    /// Gets the number of the next page.
    /// </summary>
    public int? NextPage => PageIndex.NextIndex + PageNumberIndexZero;

    /// <summary>
    /// Creates a new page with PageIndex.FirstIndex and PageNumberIndexZero set to defaults.
    /// </summary>
    /// <param name="data">The data of the current page.</param>
    /// <param name="currentIndex">The index of the current page.</param>
    /// <param name="lastIndex">The index of the last page.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <param name="totalItems">The total number of items in the search.</param>
    public Page(IReadOnlyCollection<T> data, int currentIndex, int lastIndex, uint pageSize = 25, ulong? totalItems = null)
        : this(data, new PageIndex(currentIndex, lastIndex), pageSize, totalItems) { }

    /// <summary>
    /// Creates a new page.
    /// </summary>
    /// <param name="data">The data of the current page.</param>
    /// <param name="pageIndex">The index of the current page.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <param name="totalItems">The total number of items in the search.</param>
    /// <param name="pageNumberIndexZero">The page number of the page with index zero. Default is 1.</param>
    public Page(IReadOnlyCollection<T> data, PageIndex pageIndex, uint pageSize = 25, ulong? totalItems = null, int pageNumberIndexZero = 1)
    {
        Data = data;
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalItems = totalItems;
        PageNumberIndexZero = pageNumberIndexZero;
    }
}
