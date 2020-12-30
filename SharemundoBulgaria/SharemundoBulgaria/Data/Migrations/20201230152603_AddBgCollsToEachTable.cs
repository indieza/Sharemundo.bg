namespace SharemundoBulgaria.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddBgCollsToEachTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionBg",
                table: "PartTexts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadingBg",
                table: "PartTexts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubheadingBg",
                table: "PartTexts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionBg",
                table: "JobPositions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationBg",
                table: "JobPositions",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleBg",
                table: "JobPositions",
                maxLength: 120,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionBg",
                table: "PartTexts");

            migrationBuilder.DropColumn(
                name: "HeadingBg",
                table: "PartTexts");

            migrationBuilder.DropColumn(
                name: "SubheadingBg",
                table: "PartTexts");

            migrationBuilder.DropColumn(
                name: "DescriptionBg",
                table: "JobPositions");

            migrationBuilder.DropColumn(
                name: "LocationBg",
                table: "JobPositions");

            migrationBuilder.DropColumn(
                name: "TitleBg",
                table: "JobPositions");
        }
    }
}