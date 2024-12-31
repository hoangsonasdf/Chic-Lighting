namespace projectchicandlighting.ModelViews.Product
{
    public class ProductModel
    {
        public List<ProductIndexModel> Products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? Search { get; set; }
    }
}
