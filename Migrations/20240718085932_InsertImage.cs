using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectchicandlighting.Migrations
{
    public partial class InsertImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Path", "ProductId", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy", "IsActive" },
                values: new object[,]
                {
                    { Guid.NewGuid().ToString(), "/img/lightType/w8.jpg", "753af533-e33a-4560-8463-ec6c9b748b72", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/l7.jpg", "f4b4c15e-2a22-4e43-8331-c3bdbbe286c6", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/w13.jpg", "59cd9506-46d6-4537-b103-c60897458212", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl9.jpg", "26feb3c1-25fb-4e3a-86ab-3e0378de261f", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/w14.jpg", "288da92c-3a1a-4903-b097-015d8e4a48aa", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl2.jpg", "27383f42-3cd9-4d91-ac3a-2a179de53873", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl4.jpg", "ab58309e-5353-4080-bd19-ce97898d6c6f", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl5.jpg", "b7ecb75a-61dd-42e4-a5e9-16a5226a2ce1", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl7.jpg", "2d121d76-58bc-4393-afa8-e0d6d69c55ba", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl8.jpg", "86a3b3ff-0d98-41ef-a4ac-d5a453679866", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl3.jpg", "d31784c2-21f9-4737-af38-8c7d51741410", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl10.jpg", "21885b0f-91c1-4cd5-ac2f-e1fd14200bec", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/w7.jpg", "ab01fffc-e002-43ad-9815-395b37c48acc", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/w10.jpg", "62374205-246c-4262-9063-9679393db1ed", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/l6.jpg", "5e433b33-230a-40e3-a59e-63d63c73bb8d", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/w6.jpg", "68f58a8d-ed1d-4067-8d96-2986b1fc497a", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/l1.jpg", "14e3cb59-5c26-40f7-8821-5e2278ecb72c", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/l2.jpg", "8e39f85e-2d67-43c5-a12b-e55e2e2e869e", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/l3.jpg", "7922de92-55f6-457c-83fa-9b7cc2774537", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/l4.jpg", "d9b348f0-3a32-499f-aadf-6e81f88840b8", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/l5.jpg", "f931aa1c-3bb2-442a-9c55-61fb5f7e5044", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/l8.jpg", "6f6b4552-05b1-4167-a1ef-9c7e70e6c785", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/od2.jpg", "02642c36-c769-417b-9322-cae0c3d7dcaa", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/od3.jpg", "74e506a1-1f49-421e-ad15-f71baeec814f", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/od4.jpg", "04fc938d-73d3-42cb-a002-3a7049f723bd", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/od5.jpg", "b69f253d-09f5-4c44-9d95-e7357ffd9d24", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/od6.jpg", "f84ef427-95c3-4fdd-82bb-ef40735e3105", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/f1.jpg", "17e342f3-0fd5-4205-803c-00d4b63e20d6", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/f2.jpg", "76afac8c-c2e8-4c8b-9651-b79a8cdd0c86", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha1.jpg", "1872538a-71d2-412a-9986-daf12f711ea2", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl19.jpg", "ef263f57-39e4-4349-b9d7-46ab5b37cd3d", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/w4.jpg", "2de7e612-602c-47d3-b038-2d16db00acdc", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/od1.jpg", "72fa72f6-b749-42c5-b7e5-a2ba76b350ef", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/f3.jpg", "c14af4e6-d573-431b-a7df-cac65f5244b5", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/f4.jpg", "1b5fbe83-a758-488b-99b8-8144489106d1", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/f9.jpg", "bbb37448-6f10-4cf5-ab3d-68a569e64f2b", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha2.jpg", "449cd2ab-7112-4cfe-bff5-7bf3ec9aa8d4", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha3.jpg", "b672dcd9-f5c1-4730-bd76-3e6a22b155ae", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha4.jpg", "1e896f08-4f7c-41bb-b99e-172512fe1969", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha5.jpg", "edd80736-0550-4d94-b304-49007aa5e456", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha6.jpg", "cd99f939-f57e-4b0d-9913-6ab8d7f63ad1", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/w3.jpg", "09c63539-a410-44ab-8c42-fd55f48e23ad", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/f5.jpg", "30b14517-c0d3-4742-83d5-39fec4daeafd", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha7.jpg", "ac3c23d3-c271-4870-9ffc-6fd2663bf8d2", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha8.jpg", "58fabfc6-a788-46a7-86da-2a3fbc05eb62", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha9.jpg", "39960a88-0770-4ec3-bb2c-675dc9b1dd36", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha10.jpg", "6dfad5b1-bddb-448b-9f73-1afcbf381d2c", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/cl18.jpg", "8a169ec7-5f9f-462d-994a-cf6acb4741e8", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                    { Guid.NewGuid().ToString(), "/img/lightType/ha11.jpg", "6bd47120-4b30-47c5-9c67-4a5b1f99fe44", new DateTime(2024, 4, 2, 10, 19, 54), "Admin", null, null, true },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
