using projectchicandlighting.Common;
using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Request
{
    public class AddEditProductRequest
    {
        public string? ProductId { get; set; }
        [Required(ErrorMessage = StaticMessage.RequireName)]
        [MaxLength(100, ErrorMessage = StaticMessage.MaxLengthName)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = StaticMessage.RequireQuantity)]
        [Range(1, int.MaxValue, ErrorMessage = StaticMessage.QuantityZero)]
        public int Quantity { get; set; }
        [Required(ErrorMessage = StaticMessage.RequirePrice)]
        [Range(1, double.MaxValue, ErrorMessage = StaticMessage.PriceZero)]
        public double Price { get; set; }
        public string ProductStatusId { get; set; }
        public string CategoryId { get; set; }
        public double SalePrice { get; set; }
        public List<IFormFile>? Images { get; set; }
        [Required(ErrorMessage = StaticMessage.RequireDescription)]
        public string Description { get; set; }
    }
}