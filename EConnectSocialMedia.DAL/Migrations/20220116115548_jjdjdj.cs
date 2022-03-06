using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GangstersAPP.DAL.Migrations
{
    public partial class jjdjdj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "ReactionType");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "ReactionType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$M5eHEov6I0AmpebqG8Hi.Oyv7cbFvuwMKRE3P9pCh8KPpyM7nU.y.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "ReactionType");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "ReactionType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$ox2rtBasrIENW9jjWOM/LOT.3y/5kQUKEZuYQf8sO/S2fRDmD88iW");
        }
    }
}
