using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Models
{
    public class Payment : AbstractModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}
