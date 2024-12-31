using projectchicandlighting.Models;

namespace projectchicandlighting.Repositories.CartRepositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart> GetCartByUserId(string userId);
        Task<Cart> GetCartByUser(User user);
        Task<double> GetTotalPrice(string cartId);
    }
}
