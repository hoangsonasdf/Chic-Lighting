using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Cart;

namespace projectchicandlighting.Repositories.PaymentRepositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<List<CartPaymentsModel>> GetCartPaymentsModels();
        Task<string> GetPaymentIdByName(string name);
    }
}
