using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Product;

namespace projectchicandlighting.Repositories.ProductStatusRepositories
{
    public class ProductStatusRepository : IProductStatusRepository
    {
        private readonly DatabaseContext _context;
        public ProductStatusRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task Add(ProductStatus t)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AddProductCategoryStatusModel>> GetAddProductStatusModels()
        {
            return await (from ps in _context.ProductStatuses
                          where ps.IsActive == true
                          select new AddProductCategoryStatusModel
                          {
                              Id= ps.Id,
                              Name= ps.Name,
                          })
                          .ToListAsync();
        }

        public Task<List<ProductStatus>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductStatus> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetProductStatusIdByName(string name)
        {
            return await (from ps in _context.ProductStatuses
                          where ps.IsActive == true && ps.Name == name
                          select ps.Id)
                          .SingleOrDefaultAsync();
        }

        public Task Update(string id, ProductStatus t)
        {
            throw new NotImplementedException();
        }
    }
}
