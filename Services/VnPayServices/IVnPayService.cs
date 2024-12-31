using projectchicandlighting.ModelViews.Order;
using projectchicandlighting.Request;

namespace projectchicandlighting.Services.VnPayServices
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(OrderRequest request, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
