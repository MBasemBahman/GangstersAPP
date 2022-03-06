using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GangstersAPP.DAL.Migrations
{
    public partial class mkmkms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Chat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$R7CPqzbwWAnfxhgMi4bpa.Tgu/oD7MiibthqZYmEPFpzgRQfa/8g2");

            migrationBuilder.InsertData(
                table: "SystemView",
                columns: new[] { "Id", "CreatedBy", "DisplayName", "LastModifiedBy", "Name" },
                values: new object[,]
                {
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
                    { 23, null, "ChatType", null, "ChatType" },
                    { 24, null, "Chat", null, "Chat" },
                    { 26, null, "MessageState", null, "MessageState" },
                    { 27, null, "MessageType", null, "MessageType" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Chat");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$zpYPT5y.mfINLD2XqXJQee.A7e8B/zu7zXNKLpS4vj5WNH3t/6via");
        }
    }
}
