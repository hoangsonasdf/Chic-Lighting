using PayPal.Api;
using projectchicandlighting.Request;

namespace projectchicandlighting.Services.PayPalServices
{
    public interface IPayPalService
    {
        string CreatePayment(OrderRequest request);
        Payment ExecutePayment(string paymentId, string payerId);
    }
}
