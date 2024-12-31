using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertImage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Images",
               columns: new[] { "Id", "Path", "ProductId", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy", "IsActive" },
               values: new object[,]
               {
                    { Guid.NewGuid().ToString(), "/img/lightType/CB2FA22_32A_V1_SconceGlow_1x1.jpg", "02642c36-c769-417b-9322-cae0c3d7dcaa", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/CB2FA24_23A_Hero.jpg", "02642c36-c769-417b-9322-cae0c3d7dcaa", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/GrazianoTrvtnScncInNOtdrAV4SHF22.jpg", "02642c36-c769-417b-9322-cae0c3d7dcaa", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
