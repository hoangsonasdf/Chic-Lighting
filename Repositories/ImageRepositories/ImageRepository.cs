using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Common;
using projectchicandlighting.Models;

namespace projectchicandlighting.Repositories.ImageRepositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly DatabaseContext _context;

        public ImageRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(Image t)
        {
            await _context.Images.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var image = await _context.Images
              .Where(i => i.Id == id && i.IsActive == true)
              .SingleOrDefaultAsync()
              ?? throw new Exception(StaticMessage.NotFound);

            image.IsActive = false;
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
        }

        public Task<List<Image>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Image>> GetByProductId(string id)
        {
            return await _context.Images
                .Where(i => i.IsActive == true && i.ProductId == id)
                .ToListAsync();
        }

        public async Task<List<string>> GetImagePathByProductId(string id)
        {
            return await (from i in _context.Images
                          where i.IsActive == true && i.ProductId == id
                          select i.Path)
                          .ToListAsync();
        }

        public Task Update(string id, Image t)
        {
            throw new NotImplementedException();
        }
    }
}
