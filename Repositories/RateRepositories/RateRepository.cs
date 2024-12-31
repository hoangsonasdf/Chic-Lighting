using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Rate;

namespace projectchicandlighting.Repositories.RateRepositories
{
    public class RateRepository : IRateRepository
    {
        private readonly DatabaseContext _context;
        public RateRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Rate t)
        {
            await _context.Rates.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountTotalReviewByProductId(string productId)
        {
            return await (from r in _context.Rates
                          where r.IsActive == true && r.ProductId == productId
                          group r by r.ProductId into gr
                          select gr.Count())
                          .SingleOrDefaultAsync();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Rate>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<double> GetAvarageRate(string productId)
        {
            return await (from r in _context.Rates
                          where r.IsActive == true && r.ProductId == productId
                          select (double?)r.Star)
                  .AverageAsync() ?? 0;
        }

        public Task<Rate> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RateReportModel>> GetStarReportByProductId(string productId)
        {
            var starValues = new[] { 1, 2, 3, 4, 5 };

            return  (from s in starValues
                          join r in _context.Rates.Where(r => r.ProductId == productId) on s equals r.Star
                          into rateGroup
                          from rg in rateGroup.DefaultIfEmpty()
                          group rg by s into g
                          select new RateReportModel
                          {
                              Value = g.Key,
                              Count = g.Count(rate => rate != null)
                          })
                          .ToList();
        }


        public Task Update(string id, Rate t)
        {
            throw new NotImplementedException();
        }
    }
}
