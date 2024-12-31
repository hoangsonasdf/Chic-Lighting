using Microsoft.AspNetCore.Mvc;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Cart;
using projectchicandlighting.Repositories.AuthRepositories;
using projectchicandlighting.Repositories.CartItemRepositories;
using projectchicandlighting.Repositories.CartRepositories;
using projectchicandlighting.Repositories.PaymentRepositories;
using projectchicandlighting.Repositories.ProductRepositories;
using projectchicandlighting.Request;

namespace projectchicandlighting.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAuthRepository _authRepository;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartRepository cartRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository, IPaymentRepository paymentRepository, IAuthRepository authRepository, ILogger<CartController> logger)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _paymentRepository = paymentRepository;
            _authRepository = authRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _authRepository.GetCurrentUser();
            var cart = await _cartRepository.GetCartByUser(user);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = user.Id
                };
                await _cartRepository.Add(cart);
            }
            var cartitems = await _cartItemRepository.GetCartItemModels(cart.Id);
            var payments = await _paymentRepository.GetCartPaymentsModels();
            var total = await _cartRepository.GetTotalPrice(cart.Id);
            var model = new CartModel
            {
                CartItems = cartitems,
                Payments = payments,
                Total = total,
                Request = new OrderRequest(),
                CartItemRequest = new CartItemRequest()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddToCartRequest request)
        {
            try
            {
                var user = await _authRepository.GetCurrentUser();
                var cart = await _cartRepository.GetCartByUser(user);
                if(cart == null)
                {
                    cart = new Cart
                    {
                        UserId = user.Id
                    };
                    await _cartRepository.Add(cart);
                }
                if(await _cartItemRepository.IsExistProduct(cart.Id, request.ProductId))
                {
                    TempData["AlertMessage"] = StaticMessage.ExistProduct;
                    return RedirectToAction("Index");
                }
                var product = await _productRepository.GetById(request.ProductId);
                var cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    Price = (double)((await _productRepository.HasSalePrice(request.ProductId)) ? product.Saleprice * request.Quantity : product.Price * request.Quantity),
                };
                await _cartItemRepository.Add(cartItem);
                return RedirectToAction("Index", "Product");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CartItemRequest request)
        {
            try
            {
                await _cartItemRepository.Delete(request.CartItemId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                var user = await _authRepository.GetCurrentUser();
                var cart = await _cartRepository.GetCartByUser(user);
                var cartitems = await _cartItemRepository.GetCartItemModels(cart.Id);
                var payments = await _paymentRepository.GetCartPaymentsModels();
                var total = await _cartRepository.GetTotalPrice(cart.Id);
                var model = new CartModel
                {
                    CartItems = cartitems,
                    Payments = payments,
                    Total = total,
                    Request = new OrderRequest(),
                    CartItemRequest= request,
                };
                return View("Index", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Up(CartItemRequest request)
        {
            try
            {
                await _cartItemRepository.IncreaseQuantity(request.CartItemId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                var user = await _authRepository.GetCurrentUser();
                var cart = await _cartRepository.GetCartByUser(user);
                var cartitems = await _cartItemRepository.GetCartItemModels(cart.Id);
                var payments = await _paymentRepository.GetCartPaymentsModels();
                var total = await _cartRepository.GetTotalPrice(cart.Id);
                var model = new CartModel
                {
                    CartItems = cartitems,
                    Payments = payments,
                    Total = total,
                    Request = new OrderRequest(),
                    CartItemRequest= request,
                };
                return View("Index", model);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Down(CartItemRequest request)
        {
            try
            {
                await _cartItemRepository.DecreaseQuantity(request.CartItemId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                var user = await _authRepository.GetCurrentUser();
                var cart = await _cartRepository.GetCartByUser(user);
                var cartitems = await _cartItemRepository.GetCartItemModels(cart.Id);
                var payments = await _paymentRepository.GetCartPaymentsModels();
                var total = await _cartRepository.GetTotalPrice(cart.Id);
                var model = new CartModel
                {
                    CartItems = cartitems,
                    Payments = payments,
                    Total = total,
                    Request = new OrderRequest(),
                    CartItemRequest= request,
                };
                return View("Index", model);
            }
        }
    }
}
