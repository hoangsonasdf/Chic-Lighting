using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class UpdateImage1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvatar",
                table: "Images",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvatar",
                table: "Images");
        }
    }
}
