

namespace BlogPost.Application.CommandQuery.Command
{
    public class DeleteCategoryCommand
    {
        #region Command/Query
        public sealed class Command(Guid categoryGuid) : IRequest {

            public Guid CategoryGuid { get; set; } = categoryGuid;
        }
        
        #endregion

        #region Validation
        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator(IReadonlyCategoryRepository readonlyCategoryRepository)
            {
                RuleFor(x => x.CategoryGuid)
                    .MustAsync(readonlyCategoryRepository.HasCategoryAsync)
                                         .WithMessage("Invalid category name");
            }
        }
        #endregion
    }
}
