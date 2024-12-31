using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Order;

namespace projectchicandlighting.Repositories.OrderRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<HistoryOrderModel>> GetHistoryOrderModels(string userId, string statusId);
        Task<int> GetNumberOfOrderByStatus(string userId, string statusId);
        Task<List<AllOrderModel>> GetAllOrderModels(string statusId);
        Task UpdateOrderStatus(string orderId, string statusId);
    }
}
