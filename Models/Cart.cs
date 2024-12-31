using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectchicandlighting.Models
{
    public class Cart : AbstractModel
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
