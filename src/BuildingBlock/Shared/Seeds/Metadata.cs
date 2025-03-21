namespace BuildingBlock.Shared.Seeds;

public class Metadata
{
    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int PageSize { get; set; }

    public long TotalItems { get; set; }

    public bool HasPreview => CurrentPage > 1;

    public bool HasNext => CurrentPage < TotalPages;

    public int FirstRowOnPage => TotalItems > 0 ? (CurrentPage - 1) * PageSize + 1 : 0;

    public int LastRowOnPage => (int)Math.Min(CurrentPage * PageSize, TotalItems);
}