using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Dashboard;
using projectchicandlighting.ModelViews.Home;
using projectchicandlighting.ModelViews.Product;
using projectchicandlighting.Repositories.CategoryRepository;
using projectchicandlighting.Repositories.OrderStatusRepositories;

namespace projectchicandlighting.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;
        private readonly IOrderStatusRepository _orderStatusRepository;

        public CategoryRepository(DatabaseContext context, IOrderStatusRepository orderStatusRepository)
        {
            _context = context;
            _orderStatusRepository = orderStatusRepository;
        }
        public async Task Add(Category t)
        {
            await _context.Categories.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var category = await _context.Categories
              .SingleOrDefaultAsync(c => c.Id == id && c.IsActive == true)
              ?? throw new Exception(StaticMessage.NotFound);

            category.IsActive = false;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AddProductCategoryStatusModel>> GetAddProductCategoryModels()
        {
            return await (from c in _context.Categories
                          where c.IsActive == true
                          select new AddProductCategoryStatusModel
                          {
                              Id= c.Id,
                              Name = c.Name
                          })
                          .ToListAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories
               .Where(c => c.IsActive == true)
               .ToListAsync();
        }

        public async Task<Category> GetById(string id)
        {
            return await _context.Categories
                .SingleOrDefaultAsync(c => c.Id == id && c.IsActive == true)
                ?? throw new Exception(StaticMessage.NotFound);
        }

        public async Task<List<DashboardProductCategoryModel>> GetDashboardCategoryModels(int month, int year)
        {
            var cancelStatusId = await _orderStatusRepository.GetOrderStatusIdByName(StaticOrderStatus.Canceled);
            return await (from c in _context.Categories
                          join p in _context.Products on c.Id equals p.CategoryId
                          join od in _context.OrderDetails on p.Id equals od.ProductId
                          join o in _context.Orders on od.OrderId equals o.Id
                          where o.OrderStatusId != cancelStatusId && o.CreateAt.Year == year && o.CreateAt.Month == month
                          group od by new { c.Id, c.Name } into grouped
                          orderby grouped.Sum(od => od.Quantity)
                          descending
                          select new DashboardProductCategoryModel
                          {
                              Id = grouped.Key.Id,
                              Name = grouped.Key.Name,
                              Count =  grouped.Sum(od => od.Quantity)
                          })
                          .Take(10)
                          .ToListAsync();
        }

        public async Task<List<HomeCategoryModel>> GetHomeCategoryModel()
        {
            return await (from c in _context.Categories
                          where c.IsActive == true
                          select new HomeCategoryModel
                          {
                              Id = c.Id,
                              Name = c.Name,
                              Description = c.Description,
                              Image = (from i in _context.Images
                                       join p in _context.Products on i.ProductId equals p.Id
                                       where i.IsActive == true && p.IsActive == true && p.CategoryId == c.Id
                                       select i.Path)
                                       .FirstOrDefault()
                          })
                         .ToListAsync();
        }

        public Task Update(string id, Category t)
        {
            throw new NotImplementedException();
        }
    }
}
