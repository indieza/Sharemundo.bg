namespace SharemundoBulgaria.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameSectionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameType",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "SectionType",
                table: "Sections",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SectionType",
                table: "Sections");

            migrationBuilder.AddColumn<int>(
                name: "NameType",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}