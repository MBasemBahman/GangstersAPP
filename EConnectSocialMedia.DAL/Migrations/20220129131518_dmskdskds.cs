using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GangstersAPP.DAL.Migrations
{
    public partial class dmskdskds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueName",
                table: "Account",
                type: "nvarchar(450)",
                nullable: false,
                defaultValueSql: "NEWID()");

            //migrationBuilder.InsertData(
            //    table: "Gender",
            //    columns: new[] { "Id", "ColorCode", "CreatedBy", "Name" },
            //    values: new object[] { 1, "#fff", null, "Male" });

            //migrationBuilder.InsertData(
            //    table: "Gender",
            //    columns: new[] { "Id", "ColorCode", "CreatedBy", "Name" },
            //    values: new object[] { 2, "#fff", null, "Female" });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$H8gX5PXtt1y/TyqTksxXnueM14WnFkyWsXGDPQHb254u1K0pbgTzC");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UniqueName",
                table: "Account",
                column: "UniqueName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Account_UniqueName",
                table: "Account");

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UniqueName",
                table: "Account");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$i.PzC4vq2K8ONKVl28Mg6.scG/3SuAPRq07Wb9ZG3xf71Hmpqwtue");
        }
    }
}
