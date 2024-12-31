using projectchicandlighting.Models;
using projectchicandlighting.Request;

namespace projectchicandlighting.ModelViews.Userr
{
    public class ProfileModel
    {
        public User User { get; set; }
        public ChangePasswordRequest Request { get; set; } 
    }
}
