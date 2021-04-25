using System.ComponentModel.DataAnnotations;

namespace Application.Shared
{
    public class PaginationFilterModel : BaseModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PageIndex { set; get; } = 1;

        [Required]
        [Range(1, 100)]
        public int PageSize { set; get; } = 10;
    }
}