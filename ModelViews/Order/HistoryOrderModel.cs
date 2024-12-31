namespace projectchicandlighting.ModelViews.Order
{
    public class HistoryOrderModel
    {
        public string Id { get; set; }
        public DateTime CreateAt { get; set; }
        public List<HistoryOrderDetailModel> OrderDetails { get; set; }
    }
}
