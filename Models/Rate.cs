using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectchicandlighting.Models
{
    public class Rate : AbstractModel
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }
        [Required]
        [Range(1, 5)]
        public short Star { get; set; }
        public string? Comment { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
