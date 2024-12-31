using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Order;

namespace projectchicandlighting.Repositories.OrderStatusRepositories
{
    public interface IOrderStatusRepository : IRepository<OrderStatus>
    {
        Task<string> GetOrderStatusIdByName(string name);
        Task<string> GetOrderStatusNameById (string id);
        Task<List<HistoryOrderStatusModel>> GetHistoryOrderStatusModels();
        Task<List<AdminOrderStatusOrderModel>> GetAdminOrderStatusOrders();
        Task<string> GetWaitForConfirmationId();
    }
}
