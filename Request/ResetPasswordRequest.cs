using projectchicandlighting.Common;
using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Request
{
    public class ResetPasswordRequest
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        [Required(ErrorMessage = StaticMessage.RequirePassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = StaticMessage.RequireConfirmPassword)]
        [Compare("Password", ErrorMessage = StaticMessage.PasswordMismatch)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
