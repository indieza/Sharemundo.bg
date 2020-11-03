namespace SharemundoBulgaria.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class MakeTablesForJobPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 120, nullable: false),
                    Location = table.Column<string>(maxLength: 70, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCandidates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 12, nullable: false),
                    LastName = table.Column<string>(maxLength: 12, nullable: false),
                    Phonenumber = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    CvUrl = table.Column<string>(nullable: false),
                    JobPositionId = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobCandidates_JobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidates_JobPositionId",
                table: "JobCandidates",
                column: "JobPositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCandidates");

            migrationBuilder.DropTable(
                name: "JobPositions");
        }
    }
}