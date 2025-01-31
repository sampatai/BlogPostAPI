namespace BlogPost.Domain.Aggregates.Entities;

public class BlogImage : Entity
{
    public Guid BlogImageGuid { get; set; }
    public string FileName { get; private set; }
    public string Title { get; private set; }
    public string Url { get; private set; }
    public bool IsDeleted { get; private set; }

    private BlogImage() { }

    public BlogImage(
        string fileName,
        
        string title,
        string url
    )
    {

        FileName = fileName;
        Title = title;
        Url = url;
    }
}


