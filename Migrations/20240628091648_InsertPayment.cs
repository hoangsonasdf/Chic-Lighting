using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
                values: new object[] { Guid.NewGuid().ToString(), "COD", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
                values: new object[] { Guid.NewGuid().ToString(), "Pay at shop", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
                values: new object[] { Guid.NewGuid().ToString(), "Online Banking", "Admin", null, DateTime.Now, null, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
