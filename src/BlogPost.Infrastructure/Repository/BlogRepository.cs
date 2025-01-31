namespace BlogPost.Infrastructure.Repository;

public class BlogRepository(BlogPostDbContext BlogPostDbContext,
    ILogger<BlogRepository> logger) : IBlogRepository
{
    public IUnitOfWork UnitOfWork => BlogPostDbContext;

    public async Task<Blog> AddAsync(Blog BlogPosts, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await BlogPostDbContext.Blogs.AddAsync(BlogPosts);
            return entity.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{BlogPosts}", BlogPosts);
            throw;
        }
    }

    public async Task<Blog> GetAsync(Guid BlogPostGuid, CancellationToken cancellationToken)
    {
        try
        {
            return await BlogPostDbContext
                  .Blogs
                  .Include(x => x.Images)
                  .Include(x => x.CategoryIds)
                  .AsTracking()
                  .FirstOrDefaultAsync(x => x.BlogGuid.Equals(BlogPostGuid), cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{BlogPostGuid}", BlogPostGuid);
            throw;
        }
    }

    public async Task<Blog> UpdateAsync(Blog BlogPosts, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await Task.FromResult(BlogPostDbContext.Blogs.Update(BlogPosts));
            return entity.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{BlogPosts}", BlogPosts);
            throw;
        }
    }
}

