using projectchicandlighting.Models;

namespace projectchicandlighting.Repositories.ImageRepositories
{
    public interface IImageRepository : IRepository<Image>
    {
        Task<List<Image>> GetByProductId(string id);
        Task<List<string>> GetImagePathByProductId(string id);
    }
}
