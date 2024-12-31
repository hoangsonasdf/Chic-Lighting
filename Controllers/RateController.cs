using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.Repositories.AuthRepositories;
using projectchicandlighting.Repositories.OrderStatusRepositories;
using projectchicandlighting.Repositories.ProductRepositories;
using projectchicandlighting.Repositories.RateRepositories;
using projectchicandlighting.Request;

namespace projectchicandlighting.Controllers
{
    public class RateController : Controller
    {
        private readonly IRateRepository _rateRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly ILogger<RateController> _logger;
        public RateController(IRateRepository rateRepository, IProductRepository productRepository, IAuthRepository authRepository, IOrderStatusRepository orderStatusRepository, ILogger<RateController> logger)
        {
            _rateRepository = rateRepository;
            _productRepository = productRepository;
            _authRepository = authRepository;
            _orderStatusRepository = orderStatusRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string productId)
        {
            var model = await _productRepository.GetRateIndexModel(productId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RateRequest request)
        {
            try
            {
                var user = await _authRepository.GetCurrentUser();
                var rate = new Rate
                {
                    UserId = user.Id,
                    ProductId = request.ProductId,
                    Star = request.Star,
                    Comment = request.Comment,
                };
                await _rateRepository.Add(rate);
                var statusId = await _orderStatusRepository.GetOrderStatusIdByName(StaticOrderStatus.WaitForConfirmation);
                TempData["AlertMessage"] = StaticMessage.RateSuccess;
                return RedirectToAction("History", "Order", new { statusId});
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message + ex.InnerException);
                return View(request);
            }
        }
    }
}
