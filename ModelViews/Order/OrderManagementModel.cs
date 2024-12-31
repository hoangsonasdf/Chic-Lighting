using projectchicandlighting.Request;

namespace projectchicandlighting.ModelViews.Order
{
    public class OrderManagementModel
    {
        public string StatusId { get; set; }
        public List<AllOrderModel> Orders { get; set; }
        public List<AdminOrderStatusOrderModel> Statuses { get; set; }
        public UpdateOrderRequest Request { get; set; }
    }
}
