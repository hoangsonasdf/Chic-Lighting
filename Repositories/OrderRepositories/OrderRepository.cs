using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Order;

namespace projectchicandlighting.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;
        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Order t)
        {
            await _context.Orders.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AllOrderModel>> GetAllOrderModels(string statusId)
        {
            return await (from o in _context.Orders
                          join os in _context.OrderStatuses
                          on o.OrderStatusId equals os.Id
                          join u in _context.Users
                          on o.UserId equals u.Id
                          where o.IsActive == true && o.OrderStatusId == statusId
                          select new AllOrderModel
                          {
                              Id= o.Id,
                              StatusId = o.OrderStatusId,
                              StatusName = os.Name,
                              UserId = o.UserId,
                              FirstName = o.Firstname,
                              LastName = o.LastName,
                              Address = o.Address,
                              Email = u.Email,
                              Products = (from p in _context.Products
                                          join od in _context.OrderDetails
                                          on p.Id equals od.ProductId
                                          where p.IsActive == true && od.OrderId == o.Id
                                          select new HistoryOrderDetailModel
                                          {
                                              ProductId = p.Id,
                                              Name = p.Name,
                                              Price = od.Price,
                                              Quantity = od.Quantity,
                                              Image = (from i in _context.Images
                                                       where i.IsActive == true && i.ProductId == p.Id && i.IsAvatar == true
                                                       select i.Path)
                                                       .SingleOrDefault()
                                          }) 
                                          .ToList()
                          })
                          .ToListAsync();
        }

        public Task<Order> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HistoryOrderModel>> GetHistoryOrderModels(string userId, string statusId)
        {
            return await (from o in _context.Orders
                          where o.IsActive == true && o.UserId == userId && o.OrderStatusId == statusId
                          select new HistoryOrderModel
                          {
                              Id = o.Id,
                              CreateAt = (DateTime)o.CreateAt,
                              OrderDetails = (from od in _context.OrderDetails
                                              join p in _context.Products
                                              on od.ProductId equals p.Id
                                              where od.IsActive == true && od.OrderId == o.Id
                                              select new HistoryOrderDetailModel
                                              {
                                                  ProductId = od.ProductId,
                                                  Name = p.Name,
                                                  Quantity = (int)od.Quantity,
                                                  Price = (double)od.Price,
                                                  Image = (from i in _context.Images
                                                           where i.IsActive == true && i.ProductId == p.Id && i.IsAvatar == true
                                                           select i.Path)
                                                           .SingleOrDefault()
                                              })
                                              .ToList()
                          })
                          .ToListAsync();
        }

        public async Task<int> GetNumberOfOrderByStatus(string userId, string statusId)
        {
            return await (from o in _context.Orders
                          where o.IsActive == true && o.UserId == userId && o.OrderStatusId == statusId
                          select o.Id)
                          .CountAsync();
        }

        public Task Update(string id, Order t)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrderStatus(string orderId, string statusId)
        {
            var order = await (from o in _context.Orders
                               where o.IsActive == true && o.Id == orderId
                               select o)
                               .SingleOrDefaultAsync()
                               ?? throw new Exception(StaticMessage.NotFound);
            order.OrderStatusId = statusId;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
