using Microsoft.AspNetCore.Mvc.Rendering;

namespace projectchicandlighting.ModelViews.Dashboard
{
    public class DashboardModel
    {
        public List<SelectListItem> Months { get; set; }
        public List<SelectListItem> Years { get; set; }
        public int SelectedMonth { get; set; }
        public int SelectedYear { get; set; }
        public string[] Labels { get; set; }
        public int[] Values { get; set; }
        public double[] DoubleValues { get; set; }
    }
}
