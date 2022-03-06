using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GangstersAPP.DAL.Migrations
{
    public partial class bggggvv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SystemRole",
                columns: new[] { "Id", "CreatedBy", "LastModifiedBy", "Name" },
                values: new object[] { 1, null, null, "Developer" });

            migrationBuilder.InsertData(
                table: "SystemView",
                columns: new[] { "Id", "CreatedBy", "DisplayName", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, "Home", null, "Home" },
                    { 2, null, "SystemUser", null, "SystemUser" },
                    { 3, null, "SystemView", null, "SystemView" },
                    { 4, null, "SystemRole", null, "SystemRole" },
                    { 5, null, "AppAbout", null, "AppAbout" },
                    { 6, null, "QuestionsAndAnswers", null, "QuestionsAndAnswers" },
                    { 7, null, "TermsAndConditions", null, "TermsAndConditions" },
                    { 8, null, "AppIntro", null, "AppIntro" },
                    { 9, null, "Account", null, "Account" },
                    { 10, null, "AccountState", null, "AccountState" },
                    { 11, null, "AccountType", null, "AccountType" },
                    { 12, null, "Gender", null, "Gender" },
                    { 13, null, "AccountDevice", null, "AccountDevice" },
                    { 14, null, "Message", null, "Message" },
                    { 15, null, "Group", null, "Group" },
                    { 16, null, "GroupType", null, "GroupType" },
                    { 17, null, "GroupMember", null, "GroupMember" },
                    { 18, null, "PostType", null, "PostType" },
                    { 19, null, "PostState", null, "PostState" },
                    { 20, null, "ReactionType", null, "ReactionType" },
                    { 21, null, "Post", null, "Post" },
                    { 22, null, "PostComment", null, "PostComment" },
                    { 23, null, "PostAttachment", null, "PostAttachment" },
                    { 24, null, "PostReaction", null, "PostReaction" },
                    { 25, null, "PostStateHistory", null, "PostStateHistory" },
                    { 26, null, "ChatType", null, "ChatType" },
                    { 27, null, "Chat", null, "Chat" },
                    { 28, null, "MessageState", null, "MessageState" },
                    { 29, null, "MessageType", null, "MessageType" }
                });

            migrationBuilder.InsertData(
                table: "SystemRolePremission",
                columns: new[] { "Id", "CreatedBy", "Fk_AccessLevel", "Fk_SystemRole", "Fk_SystemView", "LastModifiedBy" },
                values: new object[,]
                {
                    { 1, null, 1, 1, 1, null },
                    { 2, null, 1, 1, 2, null },
                    { 3, null, 1, 1, 3, null },
                    { 4, null, 1, 1, 4, null }
                });

            migrationBuilder.InsertData(
                table: "SystemUser",
                columns: new[] { "Id", "CreatedBy", "Email", "Expires", "Fk_SystemRole", "FullName", "IsActive", "JobTitle", "LastModifiedBy", "PasswordHash", "Phone", "Token" },
                values: new object[] { 1, null, "Developer@mail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Developer", true, "Developer", null, "$2a$11$LiUI9ZVYQcM4SaW3m92y.Ocpc/9VyLNrGKjqG9Z7gy4demnSg2EOy", "01069946657", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemRolePremission",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SystemRolePremission",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SystemRolePremission",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SystemRolePremission",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SystemRole",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
