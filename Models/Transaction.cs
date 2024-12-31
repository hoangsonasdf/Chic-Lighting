using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectchicandlighting.Models
{
    public class Transaction : AbstractModel
    {
        [ForeignKey(nameof(Order))]
        public string OrderId { get; set; }
        [ForeignKey(nameof(Payment))]
        public string PaymentId { get; set; }
        [Range(0, double.MaxValue)]
        public double Total { get; set; }

        public virtual Order Order { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
