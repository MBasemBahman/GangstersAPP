using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GangstersAPP.DAL.Migrations
{
    public partial class dmsmdskms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastActionAt",
                table: "PostComment");

            migrationBuilder.DropColumn(
                name: "ReactionCount",
                table: "PostComment");

            migrationBuilder.DropColumn(
                name: "ShareCount",
                table: "PostComment");

            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "LastActionAt",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ReactionCount",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ShareCount",
                table: "Post");

            migrationBuilder.AddColumn<string>(
                name: "PostTitle",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Message",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Chat",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Chat",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Chat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Chat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$fDGCb/YPBr9emJIbfG/Qpedfrew4k7JcyqBGO7b984hTpjbpNezym");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostTitle",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Chat");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActionAt",
                table: "PostComment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReactionCount",
                table: "PostComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShareCount",
                table: "PostComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentCount",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActionAt",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReactionCount",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShareCount",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$DU5wyHg/HWmt7H6OR5mf2OiBCQ4ea1a0sLY3QGATJtcn93bKI.nK.");
        }
    }
}
