using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EConnectSocialMedia.DAL.Migrations
{
    public partial class cnccqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fk_ServiceProviderAuthority",
                table: "ServiceProvider",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BeneficiaryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Sort = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderAuthority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Sort = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderAuthority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Account = table.Column<int>(type: "int", nullable: false),
                    Fk_BeneficiaryType = table.Column<int>(type: "int", nullable: false),
                    Fk_Governerate = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantNationalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Sort = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeneficiaryRequest_Account_Fk_Account",
                        column: x => x.Fk_Account,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryRequest_BeneficiaryType_Fk_BeneficiaryType",
                        column: x => x.Fk_BeneficiaryType,
                        principalTable: "BeneficiaryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryRequest_Governerate_Fk_Governerate",
                        column: x => x.Fk_Governerate,
                        principalTable: "Governerate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryTypeLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Sort = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeneficiaryTypeLang_BeneficiaryType_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "BeneficiaryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderAuthorityLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Sort = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderAuthorityLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderAuthorityLang_ServiceProviderAuthority_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "ServiceProviderAuthority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryRequestAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fk_BeneficiaryRequest = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileLength = table.Column<double>(type: "float", nullable: false),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryRequestAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeneficiaryRequestAttachment_BeneficiaryRequest_Fk_BeneficiaryRequest",
                        column: x => x.Fk_BeneficiaryRequest,
                        principalTable: "BeneficiaryRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$sd4BfQf9.U0EzPKhGKjpaeyvcbcZmhMfFGw79bSOtxWCZkxAug0aG");

            migrationBuilder.InsertData(
                table: "SystemView",
                columns: new[] { "Id", "CreatedBy", "DisplayName", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 40, null, "ServiceProviderAuthority", null, "ServiceProviderAuthority" },
                    { 41, null, "BeneficiaryType", null, "BeneficiaryType" },
                    { 42, null, "BeneficiaryRequest", null, "BeneficiaryRequest" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProvider_Fk_ServiceProviderAuthority",
                table: "ServiceProvider",
                column: "Fk_ServiceProviderAuthority");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryRequest_Fk_Account",
                table: "BeneficiaryRequest",
                column: "Fk_Account");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryRequest_Fk_BeneficiaryType",
                table: "BeneficiaryRequest",
                column: "Fk_BeneficiaryType");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryRequest_Fk_Governerate",
                table: "BeneficiaryRequest",
                column: "Fk_Governerate");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryRequestAttachment_Fk_BeneficiaryRequest",
                table: "BeneficiaryRequestAttachment",
                column: "Fk_BeneficiaryRequest");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryType_Name",
                table: "BeneficiaryType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryTypeLang_Fk_Source",
                table: "BeneficiaryTypeLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderAuthority_Name",
                table: "ServiceProviderAuthority",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderAuthorityLang_Fk_Source",
                table: "ServiceProviderAuthorityLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProvider_ServiceProviderAuthority_Fk_ServiceProviderAuthority",
                table: "ServiceProvider",
                column: "Fk_ServiceProviderAuthority",
                principalTable: "ServiceProviderAuthority",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProvider_ServiceProviderAuthority_Fk_ServiceProviderAuthority",
                table: "ServiceProvider");

            migrationBuilder.DropTable(
                name: "BeneficiaryRequestAttachment");

            migrationBuilder.DropTable(
                name: "BeneficiaryTypeLang");

            migrationBuilder.DropTable(
                name: "ServiceProviderAuthorityLang");

            migrationBuilder.DropTable(
                name: "BeneficiaryRequest");

            migrationBuilder.DropTable(
                name: "ServiceProviderAuthority");

            migrationBuilder.DropTable(
                name: "BeneficiaryType");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProvider_Fk_ServiceProviderAuthority",
                table: "ServiceProvider");

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DropColumn(
                name: "Fk_ServiceProviderAuthority",
                table: "ServiceProvider");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$mv4GRFHpE4nRwlCMfVAMyOKSZeqtDQz/4gCebWzgoNoe62Ev2BCMe");
        }
    }
}
