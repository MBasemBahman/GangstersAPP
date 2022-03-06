using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EConnectSocialMedia.DAL.Migrations
{
    public partial class djdjdjwjwhw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPersonName",
                table: "ServiceProviderRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPersonPhone",
                table: "ServiceProviderRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$BMkaI3/DXMZQKK8UffUGDei3sn.bi58MOn0DsoehISxLgDkaiALVW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPersonName",
                table: "ServiceProviderRequest");

            migrationBuilder.DropColumn(
                name: "ContactPersonPhone",
                table: "ServiceProviderRequest");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$sd4BfQf9.U0EzPKhGKjpaeyvcbcZmhMfFGw79bSOtxWCZkxAug0aG");
        }
    }
}
