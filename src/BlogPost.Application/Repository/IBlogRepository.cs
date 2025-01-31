namespace BlogPost.Application.Repository;

public interface IBlogRepository : IRepository<Blog>
{
    public Task<Blog> AddAsync(Blog BlogPosts, CancellationToken cancellationToken);
    public Task<Blog> UpdateAsync(Blog BlogPosts, CancellationToken cancellationToken);
    public Task<Blog> GetAsync(Guid BlogPostGuid, CancellationToken cancellationToken);
}

