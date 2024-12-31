using projectchicandlighting.Models;
using projectchicandlighting.ModelViews;
using projectchicandlighting.ModelViews.Dashboard;
using projectchicandlighting.ModelViews.Product;
using projectchicandlighting.ModelViews.Rate;

namespace projectchicandlighting.Repositories.ProductRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<ProductIndexModel>> GetProductIndexModels(int page);
        Task<List<ProductIndexModel>> GetProductIndexModelsByName(int page, string search);
        Task<ProductIndexModel> GetProductIndexModelById(string id);
        Task<RateIndexModel> GetRateIndexModel(string id);
        Task<bool> HasSalePrice(string productId);
        Task<int> GetNumberOfProduct();
        Task<int> GetNumberOfProductByName(string search);
        Task<List<DashboardProductCategoryModel>> GetDashboardProductModels(int month, int year);
        Task<List<DashboardRateModel>> GetDashboardProductRateModels();
    }
}
