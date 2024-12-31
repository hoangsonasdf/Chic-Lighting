using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Request
{
    public class OrderRequest
    {
        public List<ListProductOrderRequest> Products { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string PaymentId { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public double Total { get; set; }
    }
}
