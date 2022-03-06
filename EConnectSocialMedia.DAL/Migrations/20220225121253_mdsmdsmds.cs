using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EConnectSocialMedia.DAL.Migrations
{
    public partial class mdsmdsmds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenType = table.Column<int>(type: "int", nullable: false),
                    OpenValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Sort = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Account = table.Column<int>(type: "int", nullable: false),
                    Fk_Notification = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationAccount_Account_Fk_Account",
                        column: x => x.Fk_Account,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationAccount_Notification_Fk_Notification",
                        column: x => x.Fk_Notification,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$8HovOYzx.8lrahiW78OdpONF1aZJVHcIKOy8SDftYaQ/MQYFuddqC");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationAccount_Fk_Account",
                table: "NotificationAccount",
                column: "Fk_Account");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationAccount_Fk_Notification",
                table: "NotificationAccount",
                column: "Fk_Notification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationAccount");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$ulZMwbF3m3ygA.1hAOmAMO4nm9ufy9cMKVxN6V71jPxLcIbjz1EZa");
        }
    }
}
