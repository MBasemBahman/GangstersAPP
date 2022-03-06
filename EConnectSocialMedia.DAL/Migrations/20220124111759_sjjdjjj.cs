using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GangstersAPP.DAL.Migrations
{
    public partial class sjjdjjj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PostReaction_Fk_Post",
                table: "PostReaction");

            migrationBuilder.DropIndex(
                name: "IX_PostCommentReaction_Fk_PostComment",
                table: "PostCommentReaction");

            migrationBuilder.DropIndex(
                name: "IX_GroupMember_Fk_Group",
                table: "GroupMember");

            migrationBuilder.DropIndex(
                name: "IX_ChatMember_Fk_Chat",
                table: "ChatMember");

            migrationBuilder.AlterColumn<string>(
                name: "FileURL",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NotificationToken",
                table: "AccountDevice",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$x1iK3.lD9W2uSg2W46gmuup8tvxlqTMPoFAR2I/bL9GyoeJGVqK.m");

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_Fk_Post_Fk_Account",
                table: "PostReaction",
                columns: new[] { "Fk_Post", "Fk_Account" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentReaction_Fk_PostComment_Fk_Account",
                table: "PostCommentReaction",
                columns: new[] { "Fk_PostComment", "Fk_Account" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_Fk_Group_Fk_Account",
                table: "GroupMember",
                columns: new[] { "Fk_Group", "Fk_Account" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatMember_Fk_Chat_Fk_Account",
                table: "ChatMember",
                columns: new[] { "Fk_Chat", "Fk_Account" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountDevice_NotificationToken",
                table: "AccountDevice",
                column: "NotificationToken",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PostReaction_Fk_Post_Fk_Account",
                table: "PostReaction");

            migrationBuilder.DropIndex(
                name: "IX_PostCommentReaction_Fk_PostComment_Fk_Account",
                table: "PostCommentReaction");

            migrationBuilder.DropIndex(
                name: "IX_GroupMember_Fk_Group_Fk_Account",
                table: "GroupMember");

            migrationBuilder.DropIndex(
                name: "IX_ChatMember_Fk_Chat_Fk_Account",
                table: "ChatMember");

            migrationBuilder.DropIndex(
                name: "IX_AccountDevice_NotificationToken",
                table: "AccountDevice");

            migrationBuilder.AlterColumn<string>(
                name: "FileURL",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NotificationToken",
                table: "AccountDevice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$ZAyZB1S/3xYKBsIAjaycXuMx856C792ptC39Sndzx2uP0k9NyMYAy");

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_Fk_Post",
                table: "PostReaction",
                column: "Fk_Post");

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentReaction_Fk_PostComment",
                table: "PostCommentReaction",
                column: "Fk_PostComment");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_Fk_Group",
                table: "GroupMember",
                column: "Fk_Group");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMember_Fk_Chat",
                table: "ChatMember",
                column: "Fk_Chat");
        }
    }
}
