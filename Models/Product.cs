using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectchicandlighting.Models
{
    public class Product : AbstractModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [ForeignKey(nameof(Category))]
        public string CategoryId { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(ProductStatus))]
        public string ProductStatusId { get; set; }
        [Range(0, double.MaxValue)]
        public double? Saleprice { get; set; }

        public virtual Category Category { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<Rate>? Rates { get; set; }
        public virtual ICollection<Image>? Images { get; set; }
    }
}
