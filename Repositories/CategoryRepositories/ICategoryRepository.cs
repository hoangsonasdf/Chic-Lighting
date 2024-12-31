using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Dashboard;
using projectchicandlighting.ModelViews.Home;
using projectchicandlighting.ModelViews.Product;

namespace projectchicandlighting.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<HomeCategoryModel>> GetHomeCategoryModel();
        Task<List<DashboardProductCategoryModel>> GetDashboardCategoryModels(int month, int year);
        Task<List<AddProductCategoryStatusModel>> GetAddProductCategoryModels();
    }
}
