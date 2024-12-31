using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertPayment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "Payments",
             columns: new[] { "Id", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
             values: new object[] { Guid.NewGuid().ToString(), "Online banking (Paypal)", "Admin", null, DateTime.Now, null, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
