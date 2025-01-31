
namespace BlogPost.Application.Model.Dtos
{
    public class CategoryDTO(string name, string urlHandle)
    {
        public string Name { get; set; } = name;
        public string UrlHandle { get; set; } = urlHandle;
    }
    public class CreateCategoryDTO : CategoryDTO
    {
        public CreateCategoryDTO(string name, string urlHandle) : base(name, urlHandle)
        {
        }
    }
    public class UpdateCategoryDTO : CategoryDTO
    {
        public UpdateCategoryDTO(string name, string urlHandle,Guid categoryGuid) 
            : base(name, urlHandle)
        {
            CategoryGuid = categoryGuid;
        }

        public Guid CategoryGuid { get; set; }
    }
    public class GetCategoryDTO : UpdateCategoryDTO
    {
        public GetCategoryDTO(string name, string urlHandle, Guid categoryGuid) : base(name, urlHandle, categoryGuid)
        {
        }
    }
    public class ListCategoryDTO : PagedBase<GetCategoryDTO>
    {
        public ListCategoryDTO(IEnumerable<GetCategoryDTO> data, int totalCount) : base(data, totalCount)
        {
        }
    }
}
