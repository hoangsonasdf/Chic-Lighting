using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Models;

namespace projectchicandlighting.Repositories.OrderDetailRepositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DatabaseContext _context;
        public OrderDetailRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(OrderDetail t)
        {
            await _context.OrderDetails.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNumberOfOrderDetails(string orderId)
        {
            return await (from od in _context.OrderDetails
                          where od.IsActive == true && od.OrderId == orderId
                          select od.Id)
                          .CountAsync();
        }

        public Task Update(string id, OrderDetail t)
        {
            throw new NotImplementedException();
        }
    }
}
