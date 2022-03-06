using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EConnectSocialMedia.DAL.Migrations
{
    public partial class msdsmsk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastActionAt",
                table: "Chat",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$lP1khgyZKV/C13/7bA5WuOnRadRgozPfbiVnUG4WDNiizjO.pEuhO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastActionAt",
                table: "Chat");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$xxwVy8E/mDMAf6Jh0X0T7.nZRrXds3OEeAQccoxTbvQ02wGtzkkt2");
        }
    }
}
