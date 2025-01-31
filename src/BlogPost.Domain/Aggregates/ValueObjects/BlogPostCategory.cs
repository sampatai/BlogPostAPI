namespace BlogPost.Domain.Aggregates.ValueObjects
{
    public class BlogPostCategory
    : ValueObject
    {
        protected BlogPostCategory()
        {

        }
        public BlogPostCategory(long value)
        {
            Guard.Against.NegativeOrZero(value);
            CategoryId = value;
        }
        public long CategoryId { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CategoryId;
        }
    }
}
