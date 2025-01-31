namespace BlogPost.Shared.Exceptions;
  
public class BlogPostDomainException : Exception
{
    public BlogPostDomainException()
    { }

    public BlogPostDomainException(string message)
        : base(message)
    { }

    public BlogPostDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}

