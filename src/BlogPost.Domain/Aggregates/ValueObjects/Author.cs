
namespace BlogPost.Domain.Aggregates.ValueObjects
{
    public  class Author : ValueObject
    {
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        protected Author() { }
        public Author(string name, string lastname)
        {
            Guard.Against.NullOrEmpty(name);
            Guard.Against.NullOrEmpty(lastname);
            Firstname = name;
            Lastname = lastname;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Firstname;
            yield return Lastname;
        }
    }
}
