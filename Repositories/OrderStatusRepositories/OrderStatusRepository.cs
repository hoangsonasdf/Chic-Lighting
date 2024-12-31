using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Order;
using System.Xml.Linq;

namespace projectchicandlighting.Repositories.OrderStatusRepositories
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly DatabaseContext _context;
        public OrderStatusRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task Add(OrderStatus t)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdminOrderStatusOrderModel>> GetAdminOrderStatusOrders()
        {
            return await(from os in _context.OrderStatuses
                         where os.IsActive == true
                         select new AdminOrderStatusOrderModel
                         {
                             Id = os.Id,
                             Name = os.Name,
                         })
                          .ToListAsync();
        }

        public Task<List<OrderStatus>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderStatus> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HistoryOrderStatusModel>> GetHistoryOrderStatusModels()
        {
            return await (from os in _context.OrderStatuses
                          where os.IsActive == true
                          select new HistoryOrderStatusModel
                          {
                              Id = os.Id,
                              Name = os.Name,
                              Bootstapicon = os.Bootstapicon
                          })
                          .ToListAsync();
        }

        public async Task<string> GetOrderStatusIdByName(string name)
        {
            return await (from os in _context.OrderStatuses
                          where os.IsActive == true && os.Name == name
                          select os.Id)
                          .SingleOrDefaultAsync();
        }

        public async Task<string> GetOrderStatusNameById(string id)
        {
            return await (from os in _context.OrderStatuses
                          where os.IsActive == true && os.Id == id
                          select os.Name)
                          .SingleOrDefaultAsync();
        }

        public async Task<string> GetWaitForConfirmationId()
        {
            return await (from os in _context.OrderStatuses
                          where os.IsActive == true && os.Name == StaticOrderStatus.WaitForConfirmation
                          select os.Id)
                          .SingleOrDefaultAsync();
        }

        public Task Update(string id, OrderStatus t)
        {
            throw new NotImplementedException();
        }
    }
}
