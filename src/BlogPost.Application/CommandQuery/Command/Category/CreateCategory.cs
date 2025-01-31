namespace BlogPost.Application.CommandQuery.Command
{
    public static class CreateCategoryCommand
    {
        #region Command/Query
        public sealed class Command : CreateCategoryDTO, IRequest
        {
            public Command(string name, string urlHandle) : base(name, urlHandle)
            {
            }
        }
        #endregion

        #region Validation
        public sealed class Validator : Validator<Command>
        {
            public Validator()
            {

            }
        }
        #endregion
    }
}
