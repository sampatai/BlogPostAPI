namespace BlogPost.Domain.Aggregates.Root;

public class Category : Entity, IAggregateRoot
{
    public Guid CategoryGuid { get; private set; }
    public string Name { get; private set; }
    public UrlHandle UrlHandle { get; private set; }
    public bool IsDeleted { get; private set; }
    protected Category() { }

    public Category(string name, UrlHandle urlHandle)
    {
        Guard.Against.NullOrEmpty(name);
        Name = name;
        UrlHandle = urlHandle;
        IsDeleted = false;
    }
    public void Delete() => IsDeleted = true;

    public void SetCategory(string name, UrlHandle urlHandle)
    {
        Guard.Against.NullOrEmpty(name);
        Name = name;
        UrlHandle = urlHandle;
    }
}


