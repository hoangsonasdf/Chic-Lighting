using System.ComponentModel.DataAnnotations;

namespace projectchicandlighting.Models
{
    public abstract class AbstractModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [MaxLength(100)]
        public string? CreateBy { get; set; }
        [MaxLength(100)]
        public string? UpdateBy { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
