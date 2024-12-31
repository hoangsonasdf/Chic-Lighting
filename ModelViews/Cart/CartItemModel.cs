using projectchicandlighting.Request;

namespace projectchicandlighting.ModelViews.Cart
{
    public class CartItemModel
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
