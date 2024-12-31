using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Models
{
    public class ProductStatus : AbstractModel
    {            
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
