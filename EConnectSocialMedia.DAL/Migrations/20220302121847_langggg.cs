using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EConnectSocialMedia.DAL.Migrations
{
    public partial class langggg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountStateLang",
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
                    table.PrimaryKey("PK_AccountStateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountStateLang_AccountState_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "AccountState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypeLang",
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
                    table.PrimaryKey("PK_AccountTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTypeLang_AccountType_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppIntroLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_AppIntroLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppIntroLang_AppIntro_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "AppIntro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatTypeLang",
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
                    table.PrimaryKey("PK_ChatTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatTypeLang_ChatType_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "ChatType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenderLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_Source = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenderLang_Gender_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GovernerateLang",
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
                    table.PrimaryKey("PK_GovernerateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernerateLang_Governerate_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "Governerate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTypeLang",
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
                    table.PrimaryKey("PK_GroupTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupTypeLang_GroupType_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "GroupType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageStateLang",
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
                    table.PrimaryKey("PK_MessageStateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageStateLang_MessageState_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "MessageState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageTypeLang",
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
                    table.PrimaryKey("PK_MessageTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageTypeLang_MessageType_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "MessageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostStateLang",
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
                    table.PrimaryKey("PK_PostStateLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostStateLang_PostState_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "PostState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTypeLang",
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
                    table.PrimaryKey("PK_PostTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTypeLang_PostType_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "PostType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionsAndAnswersLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_QuestionsAndAnswersLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsAndAnswersLang_QuestionsAndAnswers_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "QuestionsAndAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReactionTypeLang",
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
                    table.PrimaryKey("PK_ReactionTypeLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReactionTypeLang_ReactionType_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "ReactionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderClassificationLang",
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
                    table.PrimaryKey("PK_ServiceProviderClassificationLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderClassificationLang_ServiceProviderClassification_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "ServiceProviderClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditionsLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_TermsAndConditionsLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TermsAndConditionsLang_TermsAndConditions_Fk_Source",
                        column: x => x.Fk_Source,
                        principalTable: "TermsAndConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$mv4GRFHpE4nRwlCMfVAMyOKSZeqtDQz/4gCebWzgoNoe62Ev2BCMe");

            migrationBuilder.CreateIndex(
                name: "IX_AccountStateLang_Fk_Source",
                table: "AccountStateLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeLang_Fk_Source",
                table: "AccountTypeLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppIntroLang_Fk_Source",
                table: "AppIntroLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatTypeLang_Fk_Source",
                table: "ChatTypeLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenderLang_Fk_Source",
                table: "GenderLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GovernerateLang_Fk_Source",
                table: "GovernerateLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupTypeLang_Fk_Source",
                table: "GroupTypeLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageStateLang_Fk_Source",
                table: "MessageStateLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageTypeLang_Fk_Source",
                table: "MessageTypeLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostStateLang_Fk_Source",
                table: "PostStateLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTypeLang_Fk_Source",
                table: "PostTypeLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsAndAnswersLang_Fk_Source",
                table: "QuestionsAndAnswersLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReactionTypeLang_Fk_Source",
                table: "ReactionTypeLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderClassificationLang_Fk_Source",
                table: "ServiceProviderClassificationLang",
                column: "Fk_Source",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TermsAndConditionsLang_Fk_Source",
                table: "TermsAndConditionsLang",
                column: "Fk_Source",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountStateLang");

            migrationBuilder.DropTable(
                name: "AccountTypeLang");

            migrationBuilder.DropTable(
                name: "AppIntroLang");

            migrationBuilder.DropTable(
                name: "ChatTypeLang");

            migrationBuilder.DropTable(
                name: "GenderLang");

            migrationBuilder.DropTable(
                name: "GovernerateLang");

            migrationBuilder.DropTable(
                name: "GroupTypeLang");

            migrationBuilder.DropTable(
                name: "MessageStateLang");

            migrationBuilder.DropTable(
                name: "MessageTypeLang");

            migrationBuilder.DropTable(
                name: "PostStateLang");

            migrationBuilder.DropTable(
                name: "PostTypeLang");

            migrationBuilder.DropTable(
                name: "QuestionsAndAnswersLang");

            migrationBuilder.DropTable(
                name: "ReactionTypeLang");

            migrationBuilder.DropTable(
                name: "ServiceProviderClassificationLang");

            migrationBuilder.DropTable(
                name: "TermsAndConditionsLang");

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$j9DEu8JDbD4f9Lun7NuMBebOnFol5WoFF/A2IWQy/aadOJY4FjfCi");
        }
    }
}
