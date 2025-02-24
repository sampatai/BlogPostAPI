using BlogPost.Application.Model.Dtos;

namespace BlogPost.Application.CommandQuery.Query
{
    public static class GetCategoryByGUID
    {
        #region Request
        public record Query(Guid CategoryGUID) : IRequest<GetCategoryDTO>
        {

        }
        #endregion
        #region Validation
        protected sealed class Validator : AbstractValidator<Query>
        {

            public Validator(IReadonlyCategoryRepository categoryRepository)
            {
                RuleFor(x => x.CategoryGUID).MustAsync(categoryRepository.HasCategoryAsync)
                                         .WithMessage("Invalid  name");
            }

        }

        #endregion

        #region Handler
        protected sealed class Handler(ILogger<Handler> logger,
                IReadonlyCategoryRepository readonlyCategoryRepository) : IRequestHandler<Query, GetCategoryDTO>
        {
            public async Task<GetCategoryDTO> Handle(Query request, CancellationToken cancellationToken)
            {

                try
                {
                    var result = await readonlyCategoryRepository.GetByIdAsync(request.CategoryGUID, cancellationToken);
                    return new GetCategoryDTO(result.Name, result.UrlHandle.Value, result.CategoryGuid);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "@{request}", request);
                    throw;
                }
            }
        }
        #endregion
    }
}