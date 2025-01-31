namespace BlogPost.Application.Projections;

public record FilterModel
{

    public required int PageNumber { get; set; } = 1;
    public required int PageSize { get; set; } = 10;
    public string SortBy { get; set; } = null;
    public string ?SortDirection { get; set; }=null;
    
}
public record TitleFilterModel: FilterModel
{
    public string? Title { get; set; } = null;
}

//public string Title { get; set; } = string.Empty;
//public DateTime? PublishedDate { get; set; } = null;