using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectchicandlighting.Models
{
    public class Image : AbstractModel
    {
        [Required]
        public string Path { get; set; }
        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public bool IsAvatar { get; set; }

    }
}
