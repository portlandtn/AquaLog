using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaLog.Migrations
{
    public partial class addMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableMeasurements",
                table: "AvailableMeasurements");

            migrationBuilder.RenameTable(
                name: "AvailableMeasurements",
                newName: "MeasurementKeys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasurementKeys",
                table: "MeasurementKeys",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    LogId = table.Column<int>(nullable: false),
                    MeasurementKeyId = table.Column<int>(nullable: false),
                    AquariumId = table.Column<int>(nullable: false),
                    Meaurement = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => new { x.AquariumId, x.MeasurementKeyId, x.LogId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasurementKeys",
                table: "MeasurementKeys");

            migrationBuilder.RenameTable(
                name: "MeasurementKeys",
                newName: "AvailableMeasurements");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableMeasurements",
                table: "AvailableMeasurements",
                column: "Id");
        }
    }
}
