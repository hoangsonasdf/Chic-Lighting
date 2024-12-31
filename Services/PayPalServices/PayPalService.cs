using PayPal.Api;
using projectchicandlighting.Request;

namespace projectchicandlighting.Services.PayPalServices
{
    public class PayPalService : IPayPalService
    {
        private readonly IConfiguration _configuration;

        public PayPalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreatePayment(OrderRequest request)
        {

            var accessToken = new OAuthTokenCredential(_configuration["PayPal:AppId"], _configuration["PayPal:AppSecret"])
                .GetAccessToken();
            var apiContext = new APIContext(accessToken);
            var payment = new Payment
            {
                intent = "sale",
                payer = new Payer
                {
                    payment_method = "paypal",
                    payer_info = new PayerInfo
                    {
                        first_name = request.FirstName,
                        last_name = request.LastName,
                    }
                },
                transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        description = "Paypal checkout",
                        invoice_number = Guid.NewGuid().ToString(),
                        amount = new Amount
                        {
                            currency = "USD",
                            total = request.Total.ToString()
                        },
                        item_list = new ItemList
                        {
                            shipping_address = new ShippingAddress
                            {
                                recipient_name = $"{request.FirstName} {request.LastName}",
                                line1 = request.Address,
                                city = "Default City",
                                state = "XX",
                                postal_code = "00000",
                                country_code = "US"
                            }
                        }
                    },

                },
                redirect_urls = new RedirectUrls
                {
                    return_url = _configuration["PayPalCallBack:ReturnUrl"],
                    cancel_url = _configuration["PayPalCallBack:CancelUrl"]
                }
            };

            var createdPayment = payment.Create(apiContext);
            var approvalUrl = createdPayment.links.FirstOrDefault(x => x.rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase))?.href;

            return approvalUrl;
        }

        public Payment ExecutePayment(string paymentId, string payerId)
        {
            var accessToken = new OAuthTokenCredential(_configuration["PayPal:AppId"], _configuration["PayPal:AppSecret"])
                .GetAccessToken();
            var apiContext = new APIContext(accessToken);
            var paymentExecution = new PaymentExecution { payer_id = payerId };
            var payment = new Payment { id = paymentId };

            var executedPayment = payment.Execute(apiContext, paymentExecution);

            return executedPayment;
        }
    }
}
