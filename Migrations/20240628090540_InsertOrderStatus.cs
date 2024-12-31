using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "OrderStatuses",
              columns: new[] { "Id", "Name", "Bootstapicon", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
              values: new object[] { Guid.NewGuid().ToString(), "Wait for delivery", "bi bi-hourglass", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
              table: "OrderStatuses",
              columns: new[] { "Id", "Name", "Bootstapicon", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
              values: new object[] { Guid.NewGuid().ToString(), "Shipping", "bi bi-truck", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
              table: "OrderStatuses",
              columns: new[] { "Id", "Name", "Bootstapicon", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
              values: new object[] { Guid.NewGuid().ToString(), "Accomplished", "bi bi-calendar2-check", "Admin", null, DateTime.Now, null, true });            
            migrationBuilder.InsertData(
              table: "OrderStatuses",
              columns: new[] { "Id", "Name", "Bootstapicon", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
              values: new object[] { Guid.NewGuid().ToString(), "Canceled", "bi bi-box-seam", "Admin", null, DateTime.Now, null, true });            
            migrationBuilder.InsertData(
              table: "OrderStatuses",
              columns: new[] { "Id", "Name", "Bootstapicon", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
              values: new object[] { Guid.NewGuid().ToString(), "Wait for confirmation", "bi bi-clock", "Admin", null, DateTime.Now, null, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
