using System;
namespace BlogPost.Infrastructure.Extensions
{

    public class SortHelper : Enumeration
    {
        public static SortHelper Desc = new(1, "desc");
        public static SortHelper Asc = new(2, "asc");
        public static SortHelper OrderByDescending = new(3, "OrderByDescending");
        public static SortHelper OrderBy = new(4, "OrderBy");
        public SortHelper(int id, string name) : base(id, name)
        {
        }
    }

}
