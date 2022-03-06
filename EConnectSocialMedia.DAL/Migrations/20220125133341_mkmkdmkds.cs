using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EConnectSocialMedia.DAL.Migrations
{
    public partial class mkmkdmkds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "AccountState",
            //    columns: new[] { "Id", "ColorCode", "CreatedBy", "LastModifiedBy", "Name" },
            //    values: new object[,]
            //    {
            //        { 1, "#fff", null, null, "Active" },
            //        { 2, "#fff", null, null, "Inactive" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AccountType",
            //    columns: new[] { "Id", "ColorCode", "CreatedBy", "LastModifiedBy", "Name" },
            //    values: new object[,]
            //    {
            //        { 1, "#fff", null, null, "Visitor" },
            //        { 2, "#fff", null, null, "Employee" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "PostState",
            //    columns: new[] { "Id", "ColorCode", "CreatedBy", "LastModifiedBy", "Name" },
            //    values: new object[,]
            //    {
            //        { 1, "#fff", null, null, "Pending" },
            //        { 2, "#fff", null, null, "Active" }
            //    });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$i.PzC4vq2K8ONKVl28Mg6.scG/3SuAPRq07Wb9ZG3xf71Hmpqwtue");

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayName",
                value: "Home");

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayName",
                value: "SystemUser");

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayName",
                value: "SystemView");

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 4,
                column: "DisplayName",
                value: "SystemRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountState",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountState",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostState",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostState",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$rcVzu../eG7CVozTi7DFueQ8BRlf/RgIHLDzuurakoMoeqcsJY18u");

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                column: "DisplayName",
                value: "Home Page");

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                column: "DisplayName",
                value: "System Users");

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                column: "DisplayName",
                value: "System Views");

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 4,
                column: "DisplayName",
                value: "System Roles");
        }
    }
}
