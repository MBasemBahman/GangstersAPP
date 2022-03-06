using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EConnectSocialMedia.DAL.Migrations
{
    public partial class jjhh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$ulZMwbF3m3ygA.1hAOmAMO4nm9ufy9cMKVxN6V71jPxLcIbjz1EZa");

            migrationBuilder.InsertData(
                table: "SystemView",
                columns: new[] { "Id", "CreatedBy", "DisplayName", "LastModifiedBy", "Name" },
                values: new object[] { 30, null, "PostCommentReaction", null, "PostCommentReaction" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$LiUI9ZVYQcM4SaW3m92y.Ocpc/9VyLNrGKjqG9Z7gy4demnSg2EOy");
        }
    }
}
