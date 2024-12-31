using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Product;

namespace projectchicandlighting.Repositories.ProductStatusRepositories
{
    public interface IProductStatusRepository : IRepository<ProductStatus>
    {
        Task<string> GetProductStatusIdByName (string name);
        Task<List<AddProductCategoryStatusModel>> GetAddProductStatusModels();
    }
}
