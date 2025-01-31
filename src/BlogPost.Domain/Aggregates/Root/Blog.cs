using BlogPost.Domain.Aggregates.Events;

namespace BlogPost.Domain.Aggregates.Root
{
    public class Blog : Entity, IAggregateRoot
    {
        private List<BlogImage> _Images = new();
        private List<BlogPostCategory> _CategoryIds = new();
        public Guid BlogGuid { get; set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Content { get; private set; }
        public FeaturedImage FeaturedImage { get; private set; } // Value object
        public UrlHandle UrlHandle { get; private set; } // Value object
        public DateTime? PublishedDate { get; private set; }
        public Author Author { get; private set; } // Value object
        public bool IsVisible { get; private set; }

        // Reference other aggregates by ID
        public IReadOnlyList<BlogPostCategory> CategoryIds => _CategoryIds.AsReadOnly();

        // Entities within the aggregate
        public IReadOnlyList<BlogImage> Images => _Images.AsReadOnly();

        public bool IsDeleted { get;private set; }

        protected Blog() { }

        public Blog(
            string title,
            string shortDescription,
            string content,
            FeaturedImage featuredImage,
            Author author
        )
        {
            Guard.Against.NullOrEmpty(title);
            Guard.Against.Null(author);
            Guard.Against.NullOrEmpty(shortDescription);
            BlogGuid = Guid.NewGuid();
            Title = title;
            ShortDescription = shortDescription;
            Content = content;
            FeaturedImage = featuredImage;
            UrlHandle = new UrlHandle(title);
            Author = author;
            IsVisible = false;
            AddDomainEvent(new BlogPostAddedEvent(BlogGuid, Title));

        }

        public void Published()
        {
            PublishedDate = DateTime.UtcNow;
            IsVisible = true;
            AddDomainEvent(new BlogPostPublishedEvent(BlogGuid, Title));
        }
        public void AddImage(BlogImage image) => _Images.Add(image);
        public void AddCategory(BlogPostCategory categoryId) => _CategoryIds.Add(categoryId);
    }
}
