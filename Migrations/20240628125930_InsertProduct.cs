using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Title", "Price", "CategoryId", "Description", "Quantity", "IsActive", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy", "Image", "ProductStatusId", "Saleprice" },
                values: new object[,]
                {
                    { Guid.NewGuid().ToString(), "CYPRESS CHAMPAGNE DOUBLE WALL SCONCE", null, 379.00m, "e1ebd017-8c14-4bc6-bac5-65267de96d03", "", 17, true, new DateTime(2024, 4, 2, 10, 19, 54), null, new DateTime(2024, 5, 15, 15, 28, 35), "admin", "/img/lightType/w8.jpg", "601489af-b93d-4b0a-b353-e14f243ab8e2", 179.00m },
                    { Guid.NewGuid().ToString(), "ELEONORA MARBLE TABLE LAMP", null, 999.00m, "f0c60493-103b-4454-80fb-5699c2f0cf08", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...", 7, true, new DateTime(2024, 4, 2, 10, 19, 54), null, null, null, "/img/lightType/l7.jpg", "601489af-b93d-4b0a-b353-e14f243ab8e2", 799.00m },
                    { Guid.NewGuid().ToString(), "SABINE POLISHED BRASS ARTICULATING WALL SCONCE", null, 199.00m, "e1ebd017-8c14-4bc6-bac5-65267de96d03", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...", 10, true, new DateTime(2024, 4, 2, 10, 19, 54), null, null, null, "/img/lightType/w13.jpg", "183913c1-404e-46af-bde2-fd03ac3faf05", null },
                    { Guid.NewGuid().ToString(), "LAMINA POLISHED BRASS PENDANT LIGHT", null, 449.00m, "e063fa2c-4037-45c1-a91d-357b7b0ee36e", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...", 12, true, new DateTime(2024, 4, 2, 10, 19, 54), null, null, null, "/img/lightType/cl9.jpg", "097a3a3f-6e30-4131-aaa5-b7da5ebc6871", null },
                    { Guid.NewGuid().ToString(), "SABINE BLACKENED BRASS ARTICULATING WALL SCONCE", null, 199.00m, "e1ebd017-8c14-4bc6-bac5-65267de96d03", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...", 10, true, new DateTime(2024, 4, 2, 10, 19, 54), null, null, null, "/img/lightType/w14.jpg", "183913c1-404e-46af-bde2-fd03ac3faf05", null },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
