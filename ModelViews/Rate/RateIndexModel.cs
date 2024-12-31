using projectchicandlighting.Request;

namespace projectchicandlighting.ModelViews.Rate
{
    public class RateIndexModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public RateRequest Request { get; set; }
    }
}
