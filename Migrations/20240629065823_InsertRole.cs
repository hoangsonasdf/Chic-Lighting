using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            values: new object[,]
            {
                {  Guid.NewGuid().ToString(), "Admin", "ADMIN", Guid.NewGuid().ToString() },
                {  Guid.NewGuid().ToString(), "User", "USER", Guid.NewGuid().ToString() }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
