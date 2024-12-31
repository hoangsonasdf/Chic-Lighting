using projectchicandlighting.Common;
using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = StaticMessage.RequireUsername)]
        [MaxLength(100, ErrorMessage = StaticMessage.MaxLengthUsername)]
        public string Username { get; set; }

        [Required(ErrorMessage = StaticMessage.RequirePassword)]
        public string Password { get; set; }
    }
}
