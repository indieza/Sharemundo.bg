namespace SharemundoBulgaria.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class MakeBasePagesDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PageName = table.Column<string>(maxLength: 25, nullable: false),
                    PositionNumber = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionImages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SectionId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionImages_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionTexts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Heading = table.Column<string>(nullable: true),
                    Subheading = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SectionId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionTexts_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionImages_SectionId",
                table: "SectionImages",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionTexts_SectionId",
                table: "SectionTexts",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionImages");

            migrationBuilder.DropTable(
                name: "SectionTexts");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}