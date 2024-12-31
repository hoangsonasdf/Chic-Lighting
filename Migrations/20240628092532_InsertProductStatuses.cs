using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertProductStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "ProductStatuses",
               columns: new[] { "Id", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
               values: new object[] { Guid.NewGuid().ToString(), "avaiable", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
               table: "ProductStatuses",
               columns: new[] { "Id", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
               values: new object[] { Guid.NewGuid().ToString(), "sale", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
               table: "ProductStatuses",
               columns: new[] { "Id", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
               values: new object[] { Guid.NewGuid().ToString(), "bestseller", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
               table: "ProductStatuses",
               columns: new[] { "Id", "Name", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
               values: new object[] { Guid.NewGuid().ToString(), "outofstock", "Admin", null, DateTime.Now, null, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
