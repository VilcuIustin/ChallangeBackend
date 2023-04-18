using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Requests
{
    public class BasePagination
    {
        [Range(0, int.MaxValue)]
        public int Page { get; set; } = 0;
        [Range(5, int.MaxValue)]
        public int Size { get; set; } = 10;
    }
}
