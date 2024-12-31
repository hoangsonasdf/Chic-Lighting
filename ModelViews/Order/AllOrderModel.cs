namespace projectchicandlighting.ModelViews.Order
{
    public class AllOrderModel
    {
        public string Id { get; set; }
        public string StatusId { get; set; }
        public string StatusName { get; set; }
        public List<HistoryOrderDetailModel> Products { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
