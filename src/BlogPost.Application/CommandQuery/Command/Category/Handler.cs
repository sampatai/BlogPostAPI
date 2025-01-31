
namespace BlogPost.Application.CommandQuery.Command
{
    public sealed class Handler(ILogger<Handler> logger,
    ICategoryRepository  categoryRepository) : IRequestHandler<CreateCategoryCommand.Command>,
     IRequestHandler<UpdateCategoryCommand.Command>,
        IRequestHandler<DeleteCategoryCommand.Command>
    
    {
        public async Task Handle(UpdateCategoryCommand.Command request, CancellationToken cancellationToken)
        {
            try
            {
                var singleCategory = await categoryRepository.GetByIdAsync(request.CategoryGuid, cancellationToken);
                singleCategory.SetCategory(request.Name,new UrlHandle(request.UrlHandle));


                await categoryRepository.UpdateAsync(singleCategory, cancellationToken);
                await categoryRepository.UnitOfWork.SaveEntitiesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{@request}", request);
                throw;
            }
        }

        public async Task Handle(CreateCategoryCommand.Command request, CancellationToken cancellationToken)
        {
            try
            {
                var category = new Category(request.Name, new UrlHandle(request.UrlHandle));

                await categoryRepository.CreateAsync(category, cancellationToken);
                await categoryRepository.UnitOfWork.SaveEntitiesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{@request}", request);
                throw;
            }
        }

        public async Task Handle(DeleteCategoryCommand.Command request, CancellationToken cancellationToken)
        {
            try
            {
                var singleCategory = await categoryRepository.GetByIdAsync(request.CategoryGuid, cancellationToken);
                singleCategory.Delete();


                await categoryRepository.UpdateAsync(singleCategory, cancellationToken);
                await categoryRepository.UnitOfWork.SaveEntitiesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{@request}", request);
                throw;
            }
        }

     
    }
}