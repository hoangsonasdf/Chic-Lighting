using projectchicandlighting.Models;
using projectchicandlighting.Request;

namespace projectchicandlighting.ModelViews.Auth
{
    public class VerifyModel
    {
        public User User { get; set; }
        public string Token { get; set; }
        public VerifyRequest Request { get; set; }
    }
}
