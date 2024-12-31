using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace projectchicandlighting.Models
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }  
        public virtual DbSet<Category> Categories { get; set; }  
        public virtual DbSet<Feedback> Feedbacks { get; set; }  
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }  
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }  
        public virtual DbSet<Payment> Payments { get; set; }  
        public virtual DbSet<Product> Products { get; set; }  
        public virtual DbSet<ProductStatus> ProductStatuses { get; set; }  
        public virtual DbSet<Rate> Rates { get; set; }  
        public virtual DbSet<Transaction> Transactions { get; set; }  
        public virtual DbSet<Image> Images { get; set; }  
    }
}
