using System.ComponentModel.DataAnnotations;

namespace Common.DTOs.Requests
{
    public class EditProductRewardRequest
    {
        public Guid Id { get; set; }
        [Range(0, int.MaxValue)]
        public int Reward { get; set; }
    }
}
