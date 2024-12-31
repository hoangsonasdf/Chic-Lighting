
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Dashboard;

namespace projectchicandlighting.Repositories.TransactionRepositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<List<DashboardProfitModel>> GetDashboardProfitModels(int year);
    }
}
