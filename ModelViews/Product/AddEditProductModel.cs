using projectchicandlighting.Request;

namespace projectchicandlighting.ModelViews.Product
{
    public class AddEditProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public double? SalePrice { get; set; }
        public string Category { get; set; }
        public List<string>? Images { get; set; }
        public string Description { get; set; }
        public List<AddProductCategoryStatusModel> Categories { get; set; }
        public List<AddProductCategoryStatusModel> Statuses { get; set; }
        public AddEditProductRequest Request { get; set; }
    }
}
