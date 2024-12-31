using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Models
{
    public class OrderStatus : AbstractModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Bootstapicon { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
