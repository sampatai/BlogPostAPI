namespace BlogPost.Application.Repository;

public interface IReadOnlyBlogRepository : IReadOnlyRepository<Blog>
{
    public Task<(IEnumerable<Blog> BlogPosts, int TotalCount)> GetBlogPosts(TitleFilterModel searchModel,CancellationToken cancellationToken);
    public Task<bool> HasBlogPosts(Guid BlogPostGuid,CancellationToken cancellationToken);
    Task<Blog> GetAsync(Guid BlogPostGuid, CancellationToken cancellationToken);
}

