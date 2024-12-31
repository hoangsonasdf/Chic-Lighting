using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class UpdateImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Images",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_UserId",
                table: "Images",
                newName: "IX_Images_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Images",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                newName: "IX_Images_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
