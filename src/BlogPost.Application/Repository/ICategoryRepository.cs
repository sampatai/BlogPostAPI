namespace BlogPost.Application.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> CreateAsync(Category category, CancellationToken cancellationToken);
        Task<Category> UpdateAsync(Category category, CancellationToken cancellationToken);
        Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
    public interface IReadonlyCategoryRepository : IReadOnlyRepository<Category>
    {
        Task<(IEnumerable<Category> Categories, int TotalCount)> GetAllAsync(
           TitleFilterModel titleFilterModel, CancellationToken cancellationToken
            );
        Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationToken);
         Task<bool> HasCategoryAsync(Guid CategoryGuid, CancellationToken cancellationToken);
    }
}
