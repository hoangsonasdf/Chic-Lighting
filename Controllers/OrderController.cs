using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using projectchicandlighting.Common;
using projectchicandlighting.Models;
using projectchicandlighting.ModelViews.Cart;
using projectchicandlighting.ModelViews.Order;
using projectchicandlighting.Repositories.AuthRepositories;
using projectchicandlighting.Repositories.CartItemRepositories;
using projectchicandlighting.Repositories.CartRepositories;
using projectchicandlighting.Repositories.OrderDetailRepositories;
using projectchicandlighting.Repositories.OrderRepositories;
using projectchicandlighting.Repositories.OrderStatusRepositories;
using projectchicandlighting.Repositories.PaymentRepositories;
using projectchicandlighting.Repositories.ProductRepositories;
using projectchicandlighting.Repositories.ProductStatusRepositories;
using projectchicandlighting.Repositories.TransactionRepositories;
using projectchicandlighting.Request;
using projectchicandlighting.Services.PayPalServices;
using projectchicandlighting.Services.VnPayServices;

namespace projectchicandlighting.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IProductStatusRepository _productStatusRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IVnPayService _vnPayService;
        private readonly IPayPalService _payPalService;

        public OrderController(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, ITransactionRepository transactionRepository, IProductRepository productRepository, ICartRepository cartRepository, ICartItemRepository cartItemRepository, IPaymentRepository paymentRepository, IOrderStatusRepository orderStatusRepository, IProductStatusRepository productStatusRepository, IAuthRepository authRepository, IVnPayService vnPayService, IPayPalService payPalService)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _paymentRepository = paymentRepository;
            _orderStatusRepository = orderStatusRepository;
            _productStatusRepository = productStatusRepository;
            _authRepository = authRepository;
            _vnPayService = vnPayService;
            _payPalService = payPalService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> History(string statusId)
        {
            var user = await _authRepository.GetCurrentUser();
            var orders = await _orderRepository.GetHistoryOrderModels(user.Id, statusId);
            var count = await _orderRepository.GetNumberOfOrderByStatus(user.Id, statusId);
            var orderStatuses = await _orderStatusRepository.GetHistoryOrderStatusModels();
            var statusName = await _orderStatusRepository.GetOrderStatusNameById(statusId);
            var model = new HistoryModel
            {
                Count = count,
                OrderStatuses = orderStatuses,
                Orders = orders,
                StatusName = statusName,
                StatusId = statusId
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> PayPalCallback(string paymentId, string token, string PayerID)
        {
            var executedPayment = _payPalService.ExecutePayment(paymentId, PayerID);

            if (executedPayment.state.ToLower() == "approved")
            {
                var jsonString = HttpContext.Session.GetString("OrderRequest");
                var request =  JsonConvert.DeserializeObject<OrderRequest>(jsonString);
                await InsertOrder(request);
                TempData["AlertMessage"] = StaticMessage.OrderSuccess;
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                TempData["AlertMessage"] = "PayPal error";
                return RedirectToAction("Index", "Cart");
            }
        }

        [HttpGet]
        public async Task<IActionResult> VnPayCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response.VnPayResponseCode == "00")
            {
                var jsonString = HttpContext.Session.GetString("OrderRequest");
                var request = JsonConvert.DeserializeObject<OrderRequest>(jsonString);
                await InsertOrder(request);
                TempData["AlertMessage"] = StaticMessage.OrderSuccess;
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                TempData["AlertMessage"] = $"VnPay error code: {response.VnPayResponseCode}";
                return RedirectToAction("Index", "Cart");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderRequest request)
        {
            try
             {
                var VnPayId = await _paymentRepository.GetPaymentIdByName(StaticPaymentName.OnlineBankingVnPay);
                var PayPalId = await _paymentRepository.GetPaymentIdByName(StaticPaymentName.OnlineBankingPayPal);
                if (request.PaymentId == VnPayId)
                {
                    var url = _vnPayService.CreatePaymentUrl(request, HttpContext);
                    var jsonString = JsonConvert.SerializeObject(request);
                    HttpContext.Session.SetString("OrderRequest", jsonString);
                    return Redirect(url);
                }

                if(request.PaymentId == PayPalId)
                {
                    var approvalUrl =  _payPalService.CreatePayment(request);
                    var jsonString = JsonConvert.SerializeObject(request);
                    HttpContext.Session.SetString("OrderRequest", jsonString);
                    return Redirect(approvalUrl);
                }

                await InsertOrder(request);

                TempData["AlertMessage"] = StaticMessage.OrderSuccess;
                return RedirectToAction("Index", "Cart");
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
                    Request = request
                };
                return RedirectToAction("Index", "Cart");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string statusId)
        {
            var orders = await _orderRepository.GetAllOrderModels(statusId);
            var orderstatuses = await _orderStatusRepository.GetAdminOrderStatusOrders();
            var model = new OrderManagementModel
            {
                StatusId = statusId,
                Orders = orders,
                Statuses = orderstatuses
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderRequest request)
        {
            try
            {
                await _orderRepository.UpdateOrderStatus(request.OrderId, request.StatusId);
                return RedirectToAction("GetAll", "Order", new {statusId = request.StatusId});
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetAll", "Order", new { statusId = request.StatusId });
            }
        }
        private async Task InsertOrder(OrderRequest request)
        {
            var user = await _authRepository.GetCurrentUser();
            var order = new Order
            {
                Firstname = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                Phone = request.Phone,
                Notes = request.Note,
                UserId = user.Id,
                OrderStatusId = await _orderStatusRepository.GetOrderStatusIdByName(StaticOrderStatus.WaitForConfirmation),
                CreateBy = user.UserName
            };

            await _orderRepository.Add(order);
            foreach (var p in request.Products)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = p.ProductId,
                    OrderId = order.Id,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CreateBy = user.UserName
                };
                await _orderDetailRepository.Add(orderDetail);
            };
            var transaction = new Transaction
            {
                OrderId = order.Id,
                PaymentId = request.PaymentId,
                Total = request.Total,
                CreateBy = user.UserName
            };
            await _transactionRepository.Add(transaction);
            var cart = await _cartRepository.GetCartByUserId(user.Id);
            foreach (var p in request.Products)
            {
                var cartItem = await _cartItemRepository.GetCartItemByCartIdAndProductId(cart.Id, p.ProductId);
                if (cartItem != null)
                {
                    await _cartItemRepository.Delete(cartItem.Id);
                }
                var product = await _productRepository.GetById(p.ProductId);
                if (product != null)
                {
                    product.Quantity -= p.Quantity;
                    if (product.Quantity == 0)
                    {
                        product.ProductStatusId = await _productStatusRepository.GetProductStatusIdByName(StaticProductStatus.OutOfStock);
                    }
                    await _productRepository.Update(product.Id, product);
                }
            }
        }
    }
}
