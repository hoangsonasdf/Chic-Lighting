using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectchicandlighting.Models
{
    public class Order : AbstractModel
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [ForeignKey(nameof(OrderStatus))]
        public string OrderStatusId { get; set; }
        public string? Notes { get; set; }
        [Required]
        [MaxLength(100)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
