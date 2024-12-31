using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Feedbacks",
              columns: new[] { "Id", "Comment", "Rate", "Email", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
              values: new object[] { Guid.NewGuid().ToString(), "I bought the 'Modern LED Pendant Light' for my kitchen remodel, and it exceeded my expectations. Not only does it provide excellent lighting, but its sleek design also complements the contemporary style of my kitchen perfectly. Very satisfied!", 3, "michael@gmail.com", "Michael", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
              table: "Feedbacks",
              columns: new[] { "Id", "Comment", "Rate", "Email", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
              values: new object[] { Guid.NewGuid().ToString(), "I've been searching for the perfect bedside lamps for ages, and I finally found them at Chic and Lighting! The 'Vintage Glass Table Lamps' I purchased are stunning and add a cozy ambiance to my bedroom. Great selection and fast shipping!", 3, "emily@gmail.com", "Emily", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
              table: "Feedbacks",
              columns: new[] { "Id", "Comment", "Rate", "Email", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
              values: new object[] { Guid.NewGuid().ToString(), "I recently purchased the 'Elegant Crystal Chandelier' from Chic and Lighting, and I'm absolutely thrilled with it! The quality is top-notch, and it adds a touch of glamour to my dining room. Highly recommend!", 3, "sarah@gmail.com", "Sarah", "Admin", null, DateTime.Now, null, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
