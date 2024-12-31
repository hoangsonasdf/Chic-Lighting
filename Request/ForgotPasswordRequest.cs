using projectchicandlighting.Common;
using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Request
{
    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage = StaticMessage.RequireEmail)]
        [EmailAddress(ErrorMessage = StaticMessage.InvalidEmailFormat)]
        public string Email { get; set; }
    }
}
