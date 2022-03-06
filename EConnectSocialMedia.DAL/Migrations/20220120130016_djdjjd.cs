using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EConnectSocialMedia.DAL.Migrations
{
    public partial class djdjjd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fk_Group",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerificationAt",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VerificationCodeHash",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$DU5wyHg/HWmt7H6OR5mf2OiBCQ4ea1a0sLY3QGATJtcn93bKI.nK.");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Fk_Group",
                table: "Post",
                column: "Fk_Group");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Group_Fk_Group",
                table: "Post",
                column: "Fk_Group",
                principalTable: "Group",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Group_Fk_Group",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Fk_Group",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Fk_Group",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "VerificationAt",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "VerificationCodeHash",
                table: "Account");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$M5eHEov6I0AmpebqG8Hi.Oyv7cbFvuwMKRE3P9pCh8KPpyM7nU.y.");
        }
    }
}
