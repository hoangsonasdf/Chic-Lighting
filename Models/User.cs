using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual ICollection<Cart>? Carts { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Rate>? Rates { get; set; }
    }
}
