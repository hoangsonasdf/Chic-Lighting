using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Cart;

namespace projectchicandlighting.Repositories.CartItemRepositories
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        Task<bool> IsExistProduct(string cartId, string productId);
        Task<CartItem> GetCartItemByCartIdAndProductId(string cartId, string productId);
        Task<List<CartItemModel>> GetCartItemModels(string cartId);
        Task IncreaseQuantity(string id);
        Task DecreaseQuantity(string id);
    }
}
