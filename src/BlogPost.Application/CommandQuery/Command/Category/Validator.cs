namespace BlogPost.Application.CommandQuery.Command;

public abstract class Validator<T> : AbstractValidator<T> where T : CategoryDTO
{
    public Validator()
    {
        RuleFor(BlogPost => BlogPost.Name)
           .NotEmpty().WithMessage("Name is required.");

        RuleFor(BlogPost => BlogPost.UrlHandle)
            .NotEmpty().WithMessage("UrlHandle is required.");
                 
    }
    
}

