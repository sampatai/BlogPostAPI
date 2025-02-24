namespace BlogPost.Infrastructure.Repository
{
    internal class CategoryRepository(BlogPostDbContext BlogPostDbContext,
    ILogger<BlogRepository> logger) : ICategoryRepository
    {
        public IUnitOfWork UnitOfWork => BlogPostDbContext;

        public async Task<Category> CreateAsync(Category category, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await BlogPostDbContext.Categories.AddAsync(category, cancellationToken);
                return entity.Entity;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "@{category}", category);
                throw;
            }
        }

        public async Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return await BlogPostDbContext
                      .Categories
                      .AsTracking()
                      .FirstOrDefaultAsync(x => x.CategoryGuid.Equals(id), cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "@{id}", id);
                throw;
            }
        }

        public async Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await Task.FromResult(BlogPostDbContext.Categories.Update(category));
                return entity.Entity;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "@{category}", category);
                throw;
            }
        }
    }
    internal class ReadonlyCategoryRepository(BlogPostDbContext BlogPostDbContext,
    ILogger<ReadOnlyBlogPostRepository> logger) : IReadonlyCategoryRepository
    {
        public async Task<(IEnumerable<Category> Categories, int TotalCount)> GetAllAsync(TitleFilterModel titleFilterModel, CancellationToken cancellationToken)
        {
            try
            {
                var categories = BlogPostDbContext
                    .Categories
                    .AsQueryable();

                categories = categories.WhereIf(!string.IsNullOrEmpty(titleFilterModel.Title), m => m.Name.Contains(titleFilterModel.Title!, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrWhiteSpace(titleFilterModel.SortBy))
                {
                    categories = categories.SortBy(titleFilterModel.SortBy, titleFilterModel.SortDirection!);
                }
                int totalCount = await categories.CountAsync(cancellationToken);
                // Apply pagination
                var skip = (titleFilterModel.PageNumber - 1) * titleFilterModel.PageSize;
                categories = categories.Skip(skip).Take(titleFilterModel.PageSize);

                // Execute the query and return the results
                return (await categories.ToListAsync(cancellationToken), totalCount);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "@{titleFilterModel}", titleFilterModel);
                throw;
            }
        }

        public async Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return await BlogPostDbContext
                      .Categories                     
                      .FirstOrDefaultAsync(x => x.CategoryGuid.Equals(id), cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "@{id}", id);
                throw;
            }
        }

        public async Task<bool> HasCategoryAsync(Guid categoryGuid, CancellationToken cancellationToken)
        {
            try
            {
                return await BlogPostDbContext
                            .Categories
                           
                            .AnyAsync(x => x.CategoryGuid.Equals(categoryGuid),
                                     cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{@categoryGuid}", categoryGuid);
                throw;
            }
        }
    }
}
