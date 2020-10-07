using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaLog.Migrations
{
    public partial class correctAquariumIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Aquariums",
                table: "Aquariums");

            migrationBuilder.DropColumn(
                name: "AquariumId",
                table: "Aquariums");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Aquariums",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aquariums",
                table: "Aquariums",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Aquariums",
                table: "Aquariums");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Aquariums");

            migrationBuilder.AddColumn<int>(
                name: "AquariumId",
                table: "Aquariums",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aquariums",
                table: "Aquariums",
                column: "AquariumId");
        }
    }
}
