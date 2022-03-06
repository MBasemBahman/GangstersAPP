using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GangstersAPP.DAL.Migrations
{
    public partial class dhdhdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$X8JjxfqB0QpvV0dJXj0lwO0JSrvBu8gA8kTH.O3Cg9TgNVX9uFktu");

            migrationBuilder.InsertData(
                table: "SystemView",
                columns: new[] { "Id", "CreatedBy", "DisplayName", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 31, null, "ServiceProviderCategory", null, "ServiceProviderCategory" },
                    { 32, null, "ServiceProvider", null, "ServiceProvider" },
                    { 33, null, "TutorialCategory", null, "TutorialCategory" },
                    { 34, null, "TutorialItem", null, "TutorialItem" },
                    { 35, null, "Partner", null, "Partner" },
                    { 36, null, "UserFullinfoItem", null, "UserFullinfoItem" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$MEUJD3sDjvTjYzOSKUj9NeELzPGSKP6FiKjtsa.WRqd6UYz2C8bzO");
        }
    }
}
