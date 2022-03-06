using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EConnectSocialMedia.DAL.Migrations
{
    public partial class ggghb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Governerate",
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
                    table.PrimaryKey("PK_Governerate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderClassification",
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
                    table.PrimaryKey("PK_ServiceProviderClassification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Account = table.Column<int>(type: "int", nullable: false),
                    Fk_ServiceProviderClassification = table.Column<int>(type: "int", nullable: false),
                    Fk_Governerate = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommercialRecord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxCardNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantJob = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ServiceProviderRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderRequest_Account_Fk_Account",
                        column: x => x.Fk_Account,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderRequest_Governerate_Fk_Governerate",
                        column: x => x.Fk_Governerate,
                        principalTable: "Governerate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderRequest_ServiceProviderClassification_Fk_ServiceProviderClassification",
                        column: x => x.Fk_ServiceProviderClassification,
                        principalTable: "ServiceProviderClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderRequestAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fk_ServiceProviderRequest = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileLength = table.Column<double>(type: "float", nullable: false),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderRequestAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderRequestAttachment_ServiceProviderRequest_Fk_ServiceProviderRequest",
                        column: x => x.Fk_ServiceProviderRequest,
                        principalTable: "ServiceProviderRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$j9DEu8JDbD4f9Lun7NuMBebOnFol5WoFF/A2IWQy/aadOJY4FjfCi");

            migrationBuilder.CreateIndex(
                name: "IX_Governerate_Name",
                table: "Governerate",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderClassification_Name",
                table: "ServiceProviderClassification",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderRequest_Fk_Account",
                table: "ServiceProviderRequest",
                column: "Fk_Account");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderRequest_Fk_Governerate",
                table: "ServiceProviderRequest",
                column: "Fk_Governerate");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderRequest_Fk_ServiceProviderClassification",
                table: "ServiceProviderRequest",
                column: "Fk_ServiceProviderClassification");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderRequestAttachment_Fk_ServiceProviderRequest",
                table: "ServiceProviderRequestAttachment",
                column: "Fk_ServiceProviderRequest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceProviderRequestAttachment");

            migrationBuilder.DropTable(
                name: "ServiceProviderRequest");

            migrationBuilder.DropTable(
                name: "Governerate");

            migrationBuilder.DropTable(
                name: "ServiceProviderClassification");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$W54x/X2NzhvnQ3osWONVW.OKuyth90aV624fvO8aK3MHtmMHfwVha");
        }
    }
}
