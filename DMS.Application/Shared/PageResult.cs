using System.Collections.Generic;

namespace Application.Shared
{
    public class PageResult<T>
    {
        public List<T> Records { set; get; }
        public int RecordsCount { set; get; }
    }
}
