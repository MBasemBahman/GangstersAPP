using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GangstersAPP.DAL.Migrations
{
    public partial class mkmsmsk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotificationAccount_Fk_Notification",
                table: "NotificationAccount");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Notification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Notification",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$xGDF7/Uchm7P8kSfRrimAeh8kXiIhMI/zm8EtYvkK8g/K2njZFrlO");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationAccount_Fk_Notification_Fk_Account",
                table: "NotificationAccount",
                columns: new[] { "Fk_Notification", "Fk_Account" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotificationAccount_Fk_Notification_Fk_Account",
                table: "NotificationAccount");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Notification");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$8HovOYzx.8lrahiW78OdpONF1aZJVHcIKOy8SDftYaQ/MQYFuddqC");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationAccount_Fk_Notification",
                table: "NotificationAccount",
                column: "Fk_Notification");
        }
    }
}
