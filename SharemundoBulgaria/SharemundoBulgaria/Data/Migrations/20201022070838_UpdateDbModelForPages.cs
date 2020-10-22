namespace SharemundoBulgaria.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateDbModelForPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionImages");

            migrationBuilder.DropTable(
                name: "SectionTexts");

            migrationBuilder.AddColumn<string>(
                name: "PartImageId",
                table: "Sections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartTextId",
                table: "Sections",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SectionParts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PositionNumber = table.Column<int>(nullable: false),
                    SectionId = table.Column<string>(nullable: false),
                    PartTextId = table.Column<string>(nullable: true),
                    PartImageId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionParts_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartImages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SectionId = table.Column<string>(nullable: true),
                    SectionPartId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartImages_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartImages_SectionParts_SectionPartId",
                        column: x => x.SectionPartId,
                        principalTable: "SectionParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartTexts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Heading = table.Column<string>(nullable: true),
                    Subheading = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SectionId = table.Column<string>(nullable: true),
                    SectionPartId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartTexts_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartTexts_SectionParts_SectionPartId",
                        column: x => x.SectionPartId,
                        principalTable: "SectionParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PartImageId",
                table: "Sections",
                column: "PartImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_PartTextId",
                table: "Sections",
                column: "PartTextId");

            migrationBuilder.CreateIndex(
                name: "IX_PartImages_SectionId",
                table: "PartImages",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartImages_SectionPartId",
                table: "PartImages",
                column: "SectionPartId");

            migrationBuilder.CreateIndex(
                name: "IX_PartTexts_SectionId",
                table: "PartTexts",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartTexts_SectionPartId",
                table: "PartTexts",
                column: "SectionPartId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionParts_PartImageId",
                table: "SectionParts",
                column: "PartImageId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionParts_PartTextId",
                table: "SectionParts",
                column: "PartTextId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionParts_SectionId",
                table: "SectionParts",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_PartImages_PartImageId",
                table: "Sections",
                column: "PartImageId",
                principalTable: "PartImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_PartTexts_PartTextId",
                table: "Sections",
                column: "PartTextId",
                principalTable: "PartTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionParts_PartImages_PartImageId",
                table: "SectionParts",
                column: "PartImageId",
                principalTable: "PartImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SectionParts_PartTexts_PartTextId",
                table: "SectionParts",
                column: "PartTextId",
                principalTable: "PartTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_PartImages_PartImageId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_PartTexts_PartTextId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_PartImages_SectionParts_SectionPartId",
                table: "PartImages");

            migrationBuilder.DropForeignKey(
                name: "FK_PartTexts_SectionParts_SectionPartId",
                table: "PartTexts");

            migrationBuilder.DropTable(
                name: "SectionParts");

            migrationBuilder.DropTable(
                name: "PartImages");

            migrationBuilder.DropTable(
                name: "PartTexts");

            migrationBuilder.DropIndex(
                name: "IX_Sections_PartImageId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_PartTextId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "PartImageId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "PartTextId",
                table: "Sections");

            migrationBuilder.CreateTable(
                name: "SectionImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Subheading = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
    }
}