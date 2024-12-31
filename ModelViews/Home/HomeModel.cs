using projectchicandlighting.Models;

namespace projectchicandlighting.ModelViews.Home
{
    public class HomeModel
    {
        public List<HomeFeedbackModel> Feedbacks { get; set; }
        public List<HomeCategoryModel> Categories { get; set; }
        public List<string> Images { get; set; }
    }
}
