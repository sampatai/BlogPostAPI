using BlogPost.Application.Model.Dtos;

namespace BlogPost.Application.CommandQuery.Query;

public static class GetCategories
{
    #region Request
    public record Query : TitleFilterModel, IRequest<ListCategoryDTO>
    {

    }
    #endregion
    #region Validation
    public sealed class Validator : AbstractValidator<Query>
    {
        public Validator()
        {

            RuleFor(x => x.PageNumber)
                .GreaterThan(0).WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100).WithMessage("Page size must be between 1 and 100.");
        }
    }

    #endregion
    #region Handler
    public sealed class Handler(ILogger<Handler> logger,
            IReadonlyCategoryRepository readonlyCategoryRepository) : IRequestHandler<Query, ListCategoryDTO>
    {
        public async Task<ListCategoryDTO> Handle(Query request, CancellationToken cancellationToken)
        {

            try
            {
                var result = await readonlyCategoryRepository.GetAllAsync(request, cancellationToken);
                return new ListCategoryDTO(result.Categories.Select(x => new GetCategoryDTO(x.Name, x.UrlHandle.Value, x.CategoryGuid)), result.TotalCount);
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
