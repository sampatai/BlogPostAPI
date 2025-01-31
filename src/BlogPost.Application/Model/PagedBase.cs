namespace BlogPost.Application.Model
{
    public class PagedBase<T>
    {
        public IEnumerable<T> Data { get; set; } = [];
        public int TotalCount { get; set; }



        public PagedBase(IEnumerable<T> data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }
    }
}
