using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Dashboard;
using projectchicandlighting.Repositories.OrderStatusRepositories;

namespace projectchicandlighting.Repositories.TransactionRepositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DatabaseContext _context;
        private readonly IOrderStatusRepository _orderStatusRepository;
        public TransactionRepository(DatabaseContext context, IOrderStatusRepository orderStatusRepository)
        {
            _context = context;
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task Add(Transaction t)
        {
            await _context.Transactions.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transaction>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DashboardProfitModel>> GetDashboardProfitModels(int year)
        {
            var cancelStatusId = await _orderStatusRepository.GetOrderStatusIdByName(StaticOrderStatus.Canceled);
            var startDate = new DateTime(year, 1, 1);
            var endDate = new DateTime(year, 12, 31);
            var months = Enumerable.Range(0, (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month + 1)
                                   .Select(offset => startDate.AddMonths(offset));

            return  (from month in months
                        join o in _context.Orders on month equals new DateTime(o.CreateAt.Year, o.CreateAt.Month, 1) into gj
                        from subOrder in gj.DefaultIfEmpty()
                        join t in _context.Transactions on (subOrder != null ? subOrder.Id : null) equals t.OrderId into gj2
                        from subTransaction in gj2.DefaultIfEmpty()
                        group subTransaction by month into grouped
                        select new DashboardProfitModel
                        {
                            Month = grouped.Key.ToString("MMMM"),
                            Total = grouped.Sum(x => x != null ? x.Total : 0)
                        })
                        .ToList();
        }

        public Task Update(string id, Transaction t)
        {
            throw new NotImplementedException();
        }
    }
}
