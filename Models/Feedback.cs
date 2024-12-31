using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Models
{
    public class Feedback : AbstractModel
    {
        public string Comment { get; set; }
        [Required]
        [Range(1, 3)]
        public short Rate { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
