using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GangstersAPP.DAL.Migrations
{
    public partial class mkddmks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Account_Gender_Fk_Gender",
            //    table: "Account");

            migrationBuilder.AlterColumn<int>(
                name: "Fk_Gender",
                table: "Account",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$xxwVy8E/mDMAf6Jh0X0T7.nZRrXds3OEeAQccoxTbvQ02wGtzkkt2");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Gender_Fk_Gender",
                table: "Account",
                column: "Fk_Gender",
                principalTable: "Gender",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Gender_Fk_Gender",
                table: "Account");

            migrationBuilder.AlterColumn<int>(
                name: "Fk_Gender",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$xGDF7/Uchm7P8kSfRrimAeh8kXiIhMI/zm8EtYvkK8g/K2njZFrlO");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Gender_Fk_Gender",
                table: "Account",
                column: "Fk_Gender",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
