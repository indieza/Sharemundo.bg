namespace SharemundoBulgaria.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Page",
                table: "Sections");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sections",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "NameType",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PageType",
                table: "Sections",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameType",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "PageType",
                table: "Sections");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Sections",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Page",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}