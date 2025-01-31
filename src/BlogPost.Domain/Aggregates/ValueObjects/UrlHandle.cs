

namespace BlogPost.Domain.Aggregates.ValueObjects;
public class UrlHandle : ValueObject
{
    protected UrlHandle()
    {

    }
    public UrlHandle(string value)
    {
        Guard.Against.NullOrEmpty(value);

        Value = value
           .ToLower()
           .Replace(" ", "-")
           .Trim();
    }
    public string Value { get; private set; }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

