using Microsoft.EntityFrameworkCore;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Cart;
using projectchicandlighting.Repositories.ProductRepositories;
using projectchicandlighting.Request;

namespace projectchicandlighting.Repositories.CartItemRepositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly DatabaseContext _context;
        private readonly IProductRepository _productRepository;

        public CartItemRepository(DatabaseContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }
        public async Task Add(CartItem t)
        {
            await _context.CartItems.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        public async Task DecreaseQuantity(string id)
        {
            var cartItem = await _context.CartItems
              .SingleOrDefaultAsync(ci => ci.Id == id && ci.IsActive == true)
              ?? throw new Exception(StaticMessage.NotFound);
            var product = await _productRepository.GetById(cartItem.ProductId);
            cartItem.Quantity--;
            if(cartItem.Quantity == 0)
            {
                throw new Exception(StaticMessage.QuantityZero);
            }
            cartItem.Price = (double)(await _productRepository.HasSalePrice(cartItem.ProductId) ? product.Saleprice * cartItem.Quantity : product.Price * cartItem.Quantity);
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var cartItem = await _context.CartItems
              .SingleOrDefaultAsync(ci => ci.Id == id && ci.IsActive == true)
              ?? throw new Exception(StaticMessage.NotFound);

            cartItem.IsActive = false;
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public Task<List<CartItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CartItem> GetCartItemByCartIdAndProductId(string cartId, string productId)
        {
            return await (from ci in _context.CartItems
                          where ci.IsActive == true && ci.CartId == cartId && ci.ProductId == productId
                          select ci)
                          .SingleOrDefaultAsync();
        }

        public async Task<List<CartItemModel>> GetCartItemModels(string cartId)
        {
            return await (from ci in _context.CartItems
                          join
                          p in _context.Products on ci.ProductId equals p.Id
                          where ci.IsActive == true && ci.CartId == cartId 
                          select new CartItemModel
                          {
                              Id = ci.Id,
                              ProductId = ci.ProductId,
                              ProductName = p.Name,
                              Quantity = ci.Quantity,
                              Price = ci.Price,
                              Image = (from i in _context.Images
                                       where i.IsActive == true && i.ProductId == p.Id && i.IsAvatar == true
                                       select i.Path)
                                       .SingleOrDefault(),
                          })
                          .ToListAsync();
        }

        public async Task IncreaseQuantity(string id)
        {
            var cartItem = await _context.CartItems
              .SingleOrDefaultAsync(ci => ci.Id == id && ci.IsActive == true)
              ?? throw new Exception(StaticMessage.NotFound);
            var product = await _productRepository.GetById(cartItem.ProductId);
            cartItem.Quantity++;
            if (cartItem.Quantity == 0)
            {
                throw new Exception(StaticMessage.QuantityZero);
            }
            cartItem.Price = (double)(await _productRepository.HasSalePrice(cartItem.ProductId) ? product.Saleprice * cartItem.Quantity : product.Price * cartItem.Quantity);
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistProduct(string cartId, string productId)
        {
            return await _context.CartItems.AnyAsync(ci => ci.IsActive == true && ci.ProductId == productId && ci.CartId == cartId);
        }

        public Task Update(string id, CartItem t)
        {
            throw new NotImplementedException();
        }
    }
}
