using projectchicandlighting.Models;
using projectchicandlighting.Request;

namespace projectchicandlighting.ModelViews.Cart
{
    public class CartModel
    {
        public List<CartItemModel> CartItems { get; set; }
        public double Total { get; set; }
        public List<CartPaymentsModel> Payments { get; set; }
        public OrderRequest Request { get; set; }
        public CartItemRequest CartItemRequest { get; set; }
    }
}
