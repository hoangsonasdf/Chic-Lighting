using projectchicandlighting.Common;
using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Request
{
    public class FeedbackRequest
    {
        [Required(ErrorMessage = StaticMessage.RequireRate)]
        public string Rate { get; set; }
        [Required(ErrorMessage = StaticMessage.RequireName)]
        [MaxLength(100, ErrorMessage = StaticMessage.MaxLengthName)]
        public string Name { get; set; }
        [Required(ErrorMessage = StaticMessage.RequireEmail)]
        [EmailAddress(ErrorMessage = StaticMessage.InvalidEmailFormat)]
        public string Email { get; set; }
        [Required(ErrorMessage = StaticMessage.RequireComment)]
        public string Comment { get; set; }
    }
}