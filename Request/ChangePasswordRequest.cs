using projectchicandlighting.Common;
using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Request
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = StaticMessage.RequireCurrentPassword)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = StaticMessage.RequireNewPassword)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = nameof(StaticMessage.RequireConfirmPassword))]
        [Compare("NewPassword", ErrorMessage = StaticMessage.PasswordMismatch)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
