using projectchicandlighting.Request;

namespace projectchicandlighting.ModelViews.Order
{
    public class HistoryModel
    {
        public int Count { get; set; }
        public List<HistoryOrderModel> Orders { get; set; }
        public List<HistoryOrderStatusModel> OrderStatuses { get; set; }
        public string StatusName { get; set; }
        public string StatusId { get; set; }
        public RateRequest Request { get; set; }
    }
}
