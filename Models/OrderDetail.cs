using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectchicandlighting.Models
{
    public class OrderDetail : AbstractModel
    {
        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }
        [ForeignKey(nameof(Order))]
        public string OrderId { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
