using projectchicandlighting.Models;

namespace projectchicandlighting.Repositories.OrderDetailRepositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        Task<int> GetNumberOfOrderDetails(string orderId);
    }
}
