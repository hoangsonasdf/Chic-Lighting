using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Cart;

namespace projectchicandlighting.Repositories.PaymentRepositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DatabaseContext _context;

        public PaymentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task Add(Payment t)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Payment>> GetAll()
        {
            return await _context.Payments
                .Where(p => p.IsActive == true)
                .ToListAsync();
        }

        public Task<Payment> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CartPaymentsModel>> GetCartPaymentsModels()
        {
            return await (from p in _context.Payments
                          where p.IsActive == true
                          select new CartPaymentsModel
                          {
                              Id = p.Id,
                              Name = p.Name
                          })
                          .ToListAsync();
        }

        public async Task<string> GetPaymentIdByName(string name)
        {
            return await (from p in _context.Payments
                          where p.IsActive == true && p.Name == name
                          select p.Id)
                          .SingleOrDefaultAsync();
        }

        public Task Update(string id, Payment t)
        {
            throw new NotImplementedException();
        }
    }
}
