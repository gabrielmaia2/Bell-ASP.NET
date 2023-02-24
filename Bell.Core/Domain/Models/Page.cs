namespace Bell.Core.Domain.Models;

/// <summary>
/// A single page from a query containing a collection of items.
/// <para>
/// The page numbers are zero-based.
/// </para>
/// </summary>
/// <typeparam name="T">The type of the item this page contains.</typeparam>
public class Page<T>
{
    /// <summary>
    /// Gets the items in this page.
    /// </summary>
    public IReadOnlyCollection<T> Data { get; init; }

    /// <summary>
    /// Gets the zero-based number of the current page. Default is 0.
    /// </summary>
    public uint CurrentPage { get; init; } = 0;

    /// <summary>
    /// Gets the maximum number of items per page. Default is 25.
    /// </summary>
    public uint PageSize { get; init; } = 25;

    /// <summary>
    /// Gets the total number of items in this query. If null, there will always be a next page. Default is null.
    /// </summary>
    public uint? TotalItems { get; init; } = null;

    /// <summary>
    /// Gets the zero-based number of the first page in this query. Is always 0.
    /// </summary>
    public uint FirstPage => 0;

    /// <summary>
    /// Gets the zero-based number of the last page in this query.
    /// </summary>
    public uint LastPage => TotalItems == null ? CurrentPage + 1 : (uint)((TotalItems - 1) / PageSize);

    /// <summary>
    /// Determines whether there is a previous page.
    /// </summary>
    public bool HasPrevious => CurrentPage > FirstPage;

    /// <summary>
    /// Determines whether there is a next page.
    /// </summary>
    public bool HasNext => CurrentPage < LastPage;

    /// <summary>
    /// Gets the zero-based number of the previous page. Returns null if there is no previous page.
    /// </summary>
    // TODO check if it is better to return current page instead of null when no previous/next
    public uint? PreviousPage => HasPrevious ? CurrentPage - 1 : null;

    /// <summary>
    /// Gets the zero-based number of the next page. Returns null if there is no next page.
    /// </summary>
    public uint? NextPage => HasNext ? CurrentPage + 1 : null;

    /// <summary>
    /// Creates a new query page.
    /// </summary>
    /// <param name="currentIndex">The index of the current page.</param>
    /// <param name="lastIndex">The index of the last page.</param>
    /// <param name="firstIndex">The index of the first page. Default is 0.</param>
    public Page(IReadOnlyCollection<T> data, uint currentPage = 0, uint pageSize = 25, uint? totalItems = null)
    {
        Data = data;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalItems = totalItems;
    }

    /// <summary>
    /// Clones a page changing only its contents.
    /// </summary>
    /// <param name="data">The new content of the page.</param>
    /// <param name="oldPage">The page to copy.</param>
    /// <typeparam name="T2">The type of the old items.</typeparam>
    /// <returns>A clone of the page with the new content.</returns>
    public static Page<T> Clone<T2>(IReadOnlyCollection<T> data, Page<T2> oldPage)
    {
        return new Page<T>(
            data,
            oldPage.CurrentPage,
            oldPage.PageSize,
            oldPage.TotalItems
        );
    }
}
