namespace BlogPost.Application.CommandQuery.Command
{
    public static class UpdateCategoryCommand
    {
        #region Command/Query
        public sealed class Command : UpdateCategoryDTO, IRequest
        {
            public Command(string name, string urlHandle, Guid categoryGuid) : base(name, urlHandle, categoryGuid)
            {
            }         
        }
        #endregion

        #region Validation
        public sealed class Validator : Validator<Command>
        {
            public Validator(IReadonlyCategoryRepository  readonlyCategoryRepository)
            {
                RuleFor(x => x.CategoryGuid).MustAsync(readonlyCategoryRepository.HasCategoryAsync)
                                         .WithMessage("Invalid category name");
            }
        }
        #endregion
    }
}
