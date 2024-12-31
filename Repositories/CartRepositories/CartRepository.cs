using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Common;
using projectchicandlighting.Models;

namespace projectchicandlighting.Repositories.CartRepositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DatabaseContext _context;
        public CartRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task Add(Cart t)
        {
            await _context.Carts.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> GetCartByUser(User user)
        {
            return await _context.Carts
                .Where(c => c.IsActive == true && c.UserId == user.Id)
               .SingleOrDefaultAsync();
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            return await _context.Carts
                .Where(c => c.IsActive == true && c.UserId == userId)
                .SingleOrDefaultAsync();
        }

        public async Task<double> GetTotalPrice(string cartId)
        {
            return await (from c in _context.Carts join
                          ci in _context.CartItems on c.Id equals ci.CartId
                          where c.Id == cartId && c.IsActive == true && ci.IsActive == true
                          select ci.Price)
                          .SumAsync();
        }

        public Task Update(string id, Cart t)
        {
            throw new NotImplementedException();
        }
    }
}
