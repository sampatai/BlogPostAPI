

namespace BlogPost.Domain.Aggregates.ValueObjects
{
    public  class FeaturedImage : ValueObject
    {
        public string Url { get; private set; }
        public string AltText { get; private set; }

        protected FeaturedImage() { }
        public FeaturedImage(string url, string altText)
        {
            Guard.Against.NullOrEmpty(url);
            Url = url;
            AltText = altText;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Url;
            yield return AltText;
        }
    }
}
