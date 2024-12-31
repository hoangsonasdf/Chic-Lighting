using projectchicandlighting.ModelViews.Rate;
using projectchicandlighting.Request;

namespace projectchicandlighting.ModelViews.Product
{
    public class ProductIndexModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public double? SalePrice { get; set; }
        public List<string>? Image { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public List<RateReportModel>? Review { get; set; }
        public int? TotalReview { get; set; }
        public double AverageRate { get; set; }
        public AddToCartRequest Request { get; set; }
    }
}
