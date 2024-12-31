using projectchicandlighting.Common;
using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Request
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = StaticMessage.RequireFirstName)]
        [MaxLength(100, ErrorMessage = StaticMessage.MaxLengthFirstName)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = StaticMessage.RequireLastName)]
        [MaxLength(100, ErrorMessage = StaticMessage.MaxLengthLastName)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = StaticMessage.RequireUsername)]
        [MaxLength(100, ErrorMessage = StaticMessage.MaxLengthUsername)]
        public string Username { get; set; }

        [Required(ErrorMessage = StaticMessage.RequireEmail)]
        [EmailAddress(ErrorMessage = StaticMessage.InvalidEmailFormat)]
        public string Email { get; set; }

        [Required(ErrorMessage = StaticMessage.RequireAddress)]
        public string Address { get; set; }

        [Required(ErrorMessage = StaticMessage.RequirePassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = StaticMessage.RequireConfirmPassword)]
        [Compare("Password", ErrorMessage = StaticMessage.PasswordMismatch)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
