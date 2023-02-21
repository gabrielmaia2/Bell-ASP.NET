namespace Bell.Core.Domain.Models;

public class PagerIndex
{
    /// <summary>
    /// Gets the index of the current page. Default is 0.
    /// </summary>
    public int CurrentIndex { get; init; } = 0;

    /// <summary>
    /// Gets the index of the last page. Default is 0.
    /// </summary>
    public int LastIndex { get; init; } = 0;

    /// <summary>
    /// Gets the index of the first page. Default is 0.
    /// </summary>
    public int FirstIndex { get; init; } = 0;

    /// <summary>
    /// Determines whether there is a previous page.
    /// </summary>
    public bool HasPrevious => CurrentIndex > FirstIndex;

    /// <summary>
    /// Determines whether there is a next page.
    /// </summary>
    public bool HasNext => CurrentIndex < LastIndex;

    /// <summary>
    /// Gets the index of the previous page.
    /// </summary>
    // TODO check if it is better to return current page instead of null when no previous/next
    public int? PreviousIndex => HasPrevious ? CurrentIndex - 1 : null;

    /// <summary>
    /// Gets the index of the next page.
    /// </summary>
    public int? NextIndex => HasNext ? CurrentIndex + 1 : null;

    /// <summary>
    /// Creates a new page index.
    /// </summary>
    /// <param name="currentIndex">The index of the current page.</param>
    /// <param name="lastIndex">The index of the last page.</param>
    /// <param name="firstIndex">The index of the first page. Default is 0.</param>
    public PagerIndex(int currentIndex, int lastIndex, int firstIndex = 0)
    {
        CurrentIndex = currentIndex;
        LastIndex = lastIndex;
        FirstIndex = firstIndex;
    }
}
