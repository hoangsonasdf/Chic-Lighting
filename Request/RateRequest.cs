using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Request
{
    public class RateRequest
    {
        public string ProductId { get; set; }
        [Required]
        [Range(1, 5)]
        public short Star { get; set; }
        public string? Comment { get; set;}
    }
}
