using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaLog.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aquariums",
                columns: table => new
                {
                    AquariumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Freshwater = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aquariums", x => x.AquariumId);
                });

            migrationBuilder.CreateTable(
                name: "AvailableMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ApplicableToFreshwater = table.Column<bool>(nullable: false),
                    ApplicableToSaltwater = table.Column<bool>(nullable: false),
                    HighRange = table.Column<double>(nullable: false),
                    LowRange = table.Column<double>(nullable: false),
                    IdealLevel = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aquariums");

            migrationBuilder.DropTable(
                name: "AvailableMeasurements");

            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
