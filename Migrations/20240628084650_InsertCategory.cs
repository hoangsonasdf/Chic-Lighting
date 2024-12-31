using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Categories",
              columns: new[] { "Id", "Name", "Description", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
              values: new object[] { Guid.NewGuid().ToString(), "Ceiling", "Discover chic ceiling lights to elevate your space. Explore modern designs and timeless classics for a touch of elegance in any room.", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
                values: new object[] { Guid.NewGuid().ToString(), "Wall", "Add warmth and style to your walls with our stunning wall lights. From sleek sconces to elegant fixtures, our collection offers the perfect blend of form and function. Illuminate your space with ease and sophistication. Explore our selection now and brighten up your home with effortless elegance.", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
                values: new object[] { Guid.NewGuid().ToString(), "Lamp", "Illuminate your space with our exquisite lamps. From elegant table lamps to sleek floor lamps, our collection offers timeless designs and superior craftsmanship. Enhance any room with warm, inviting light and stylish accents. Explore our selection now and bring effortless elegance to your home.", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
                values: new object[] { Guid.NewGuid().ToString(), "Outdoor", "Light up your outdoor spaces with style. Explore our collection of durable and elegant outdoor lights today!", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
                values: new object[] { Guid.NewGuid().ToString(), "Fan", "Stay cool and stylish with our range of ceiling fans. From modern designs to classic styles, our collection offers the perfect blend of comfort and elegance. Enhance any room's ambiance while keeping the air flowing smoothly. Discover the ideal fan for your space today.", "Admin", null, DateTime.Now, null, true });
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Description", "CreateBy", "UpdateBy", "CreateAt", "UpdateAt", "IsActive" },
                values: new object[] { Guid.NewGuid().ToString(), "Accents", "Elevate your space with our curated selection of home accents. From decorative vases to stylish throw pillows, our collection offers the perfect finishing touches to any room. Add personality and charm to your home decor effortlessly. Explore our range of accents and transform your space today.", "Admin", null, DateTime.Now, null, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
