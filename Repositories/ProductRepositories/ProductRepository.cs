using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews;
using projectchicandlighting.ModelViews.Dashboard;
using projectchicandlighting.ModelViews.Product;
using projectchicandlighting.ModelViews.Rate;
using projectchicandlighting.Repositories.OrderStatusRepositories;
using projectchicandlighting.Request;

namespace projectchicandlighting.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        private readonly IOrderStatusRepository _orderStatusRepository;

        public ProductRepository(DatabaseContext context, IOrderStatusRepository orderStatusRepository)
        {
            _context = context;
            _orderStatusRepository = orderStatusRepository;
        }
        public async Task Add(Product t)
        {
            await _context.Products.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id && p.IsActive == true)
                .SingleOrDefaultAsync()
                ?? throw new Exception(StaticMessage.NotFound);

            product.IsActive = false;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetById(string id)
        {
            return await _context.Products
                .Where(p => p.IsActive == true && p.Id == id)
                .SingleOrDefaultAsync()
                ?? throw new Exception(StaticMessage.NotFound);
        }

        public async Task<List<DashboardProductCategoryModel>> GetDashboardProductModels(int month ,int year)
        {
            var cancelStatusId = await _orderStatusRepository.GetOrderStatusIdByName(StaticOrderStatus.Canceled);
            return await (from p in _context.Products
                          join od in _context.OrderDetails on p.Id equals od.ProductId
                          join o in _context.Orders on od.OrderId equals o.Id
                          where o.OrderStatusId != cancelStatusId && o.CreateAt.Year == year && o.CreateAt.Month == month
                          group od by new { p.Id, p.Name }
                          into grouped
                          orderby grouped.Sum(od => od.Quantity)
                          descending
                          select new DashboardProductCategoryModel
                          {
                              Id = grouped.Key.Id,
                              Name = grouped.Key.Name,
                              Count = grouped.Sum(od => od.Quantity),
                          })
                          .Take(10)
                          .ToListAsync();

        }

        public async Task<List<DashboardRateModel>> GetDashboardProductRateModels()
        {
            return await (from p in _context.Products
                          join r in _context.Rates on p.Id equals r.ProductId
                          group r by new { p.Id, p.Name }
                         into grouped
                          orderby grouped.Average(r => r.Star)
                          descending
                          select new DashboardRateModel
                          {
                              Id = grouped.Key.Id,
                              Name = grouped.Key.Name,
                              Average = grouped.Average(r => r.Star)
                          })
                          .Take(10)
                          .ToListAsync();
        }

        public async Task<int> GetNumberOfProduct()
        {
            return await (from p in _context.Products
                          where p.IsActive == true
                          select p.Id)
                         .CountAsync();
        }

        public async Task<int> GetNumberOfProductByName(string search)
        {
            return await(from p in _context.Products
                         where p.IsActive == true && p.Name.Contains(search)
                         select p.Id)
                        .CountAsync();
        }

        public async Task<ProductIndexModel> GetProductIndexModelById(string id)
        {
            return await (from p in _context.Products
                          join c in _context.Categories on p.CategoryId equals c.Id
                          join s in _context.ProductStatuses on p.ProductStatusId equals s.Id
                          where p.IsActive == true && c.IsActive == true && s.IsActive == true && p.Id == id
                          select new ProductIndexModel
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Category = c.Name,
                              Status = s.Name,
                              Price = p.Price,
                              SalePrice = p.Saleprice.HasValue ? (double)p.Saleprice.Value : 0.0,
                              Quantity = p.Quantity,
                              Image = (from i in _context.Images
                                       where i.IsActive == true && i.ProductId == p.Id
                                       orderby i.IsAvatar
                                       descending
                                       select i.Path)
                                        .ToList(),
                              Description = p.Description,
                              Request = new AddToCartRequest()
                          })
                         .SingleOrDefaultAsync();
        }

        public async Task<List<ProductIndexModel>> GetProductIndexModels(int page)
        {
            return await (from p in _context.Products
                          join c in _context.Categories on p.CategoryId equals c.Id
                          join s in _context.ProductStatuses on p.ProductStatusId equals s.Id
                          where p.IsActive == true && c.IsActive == true && s.IsActive == true
                          select new ProductIndexModel
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Category = c.Name,
                              Status = s.Name,
                              Price = p.Price,
                              SalePrice = p.Saleprice.HasValue ? (double)p.Saleprice.Value : 0.0,
                              Quantity = p.Quantity,
                              Image = (from i in _context.Images
                                       where i.IsActive == true && i.ProductId == p.Id && i.IsAvatar == true
                                       select i.Path)
                                       .Take(1)
                                       .ToList(),
                              Request = new AddToCartRequest()
                          })
                          .Skip((page - 1) * StaticPageSize.PageSize)
                          .Take(StaticPageSize.PageSize)
                          .ToListAsync();
        }

        public async Task<List<ProductIndexModel>> GetProductIndexModelsByName(int page, string search)
        {
            return await (from p in _context.Products
                          join c in _context.Categories on p.CategoryId equals c.Id
                          join s in _context.ProductStatuses on p.ProductStatusId equals s.Id
                          where p.IsActive == true && c.IsActive == true && s.IsActive == true && p.Name.Contains(search.ToUpper())
                          select new ProductIndexModel
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Category = c.Name,
                              Status = s.Name,
                              Price = p.Price,
                              SalePrice = p.Saleprice.HasValue ? (double)p.Saleprice.Value : 0.0,
                              Image = (from i in _context.Images
                                       where i.IsActive == true && i.ProductId == p.Id && i.IsAvatar == true
                                       select i.Path)
                                        .Take(1)
                                        .ToList(),
                              Request = new AddToCartRequest()
                          })
                         .Skip((page - 1) * StaticPageSize.PageSize)
                         .Take(StaticPageSize.PageSize)
                         .ToListAsync();
        }

        public async Task<RateIndexModel> GetRateIndexModel(string id)
        {
            return await (from p in _context.Products
                          where p.IsActive == true && p.Id == id
                          select new RateIndexModel
                          {
                              Name = p.Name,
                              Price = p.Price,
                              Image = (from i in _context.Images
                                       where i.IsActive == true && i.ProductId == p.Id && i.IsAvatar == true
                                       select i.Path)
                                      .SingleOrDefault(),
                              Request = new RateRequest()
                          })
                          .SingleOrDefaultAsync();
        }

        public async Task<bool> HasSalePrice(string productId)
        {
            var salePrice = await _context.Products
                .Where(p => p.IsActive == true && p.Id == productId)
                .Select(p => p.Saleprice)
                .SingleOrDefaultAsync();
            return salePrice != null;
        }

        public async Task Update(string id, Product t)
        {
            var product = await _context.Products
                .Where(p => p.IsActive == true && p.Id == id)
                .SingleOrDefaultAsync()
                ?? throw new Exception(StaticMessage.NotFound);

            product.Name = t.Name;  
            product.Price = t.Price;
            product.CategoryId = t.CategoryId;
            product.Description = t.Description;
            product.Quantity = t.Quantity;
            product.ProductStatusId = t.ProductStatusId;
            product.Saleprice = t.Saleprice;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
