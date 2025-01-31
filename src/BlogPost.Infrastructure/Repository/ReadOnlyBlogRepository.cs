using BlogPost.Application.Projections;
using BlogPost.Domain.Aggregates.Enumerations;
using BlogPost.Infrastructure.Extensions;
namespace BlogPost.Infrastructure.Repository;

public class ReadOnlyBlogPostRepository(BlogPostDbContext BlogPostDbContext,
    ILogger<ReadOnlyBlogPostRepository> logger) : IReadOnlyBlogRepository
{
    public async Task<(IEnumerable<Blog> BlogPosts, int TotalCount)> GetBlogPosts(TitleFilterModel searchModel, CancellationToken cancellationToken)
    {
        try
        {
            var query = BlogPostDbContext.Blogs
            .AsQueryable();


            query = query.WhereIf(!string.IsNullOrEmpty(searchModel.Title), m => m.Title.Contains(searchModel.Title, StringComparison.OrdinalIgnoreCase));
            
            var totalCount = await query.AsNoTracking().CountAsync(cancellationToken);

            var BlogPosts = await query.AsNoTracking()
                .Skip((searchModel.PageNumber - 1) * searchModel.PageSize)
                .Take(searchModel.PageSize)
                .ToListAsync(cancellationToken);
            return (BlogPosts, totalCount);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{searchModel}", searchModel);
            throw;
        }
    }
    public async Task<bool> HasBlogPosts(Guid BlogPostGuid, CancellationToken cancellationToken)
    {
        try
        {
            return await BlogPostDbContext
                        .Blogs
                        .AsNoTracking()
                        .AnyAsync(x => x.BlogGuid.Equals(BlogPostGuid)
                                && x.IsDeleted, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{@BlogPostGuid}", BlogPostGuid);
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
                  .AsNoTracking()
                  .FirstOrDefaultAsync(x => x.BlogGuid.Equals(BlogPostGuid), cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{BlogPostGuid}", BlogPostGuid);
            throw;
        }
    }
}

