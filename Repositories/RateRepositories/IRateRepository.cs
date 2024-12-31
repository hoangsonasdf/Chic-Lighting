using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Rate;

namespace projectchicandlighting.Repositories.RateRepositories
{
    public interface IRateRepository : IRepository<Rate>
    {
        Task<List<RateReportModel>> GetStarReportByProductId(string productId);
        Task<int> CountTotalReviewByProductId(string productId);
        Task<double> GetAvarageRate(string productId);
    }
}
