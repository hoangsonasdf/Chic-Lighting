using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Models
{
    public class Category : AbstractModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
