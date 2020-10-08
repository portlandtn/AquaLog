using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaLog.Migrations
{
    public partial class setupForeignKeysOnMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Measurements_LogId",
                table: "Measurements",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_MeasurementKeyId",
                table: "Measurements",
                column: "MeasurementKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Aquarium",
                table: "Measurements",
                column: "AquariumId",
                principalTable: "Aquariums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_Log",
                table: "Measurements",
                column: "LogId",
                principalTable: "Logs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurement_MeasurementKey",
                table: "Measurements",
                column: "MeasurementKeyId",
                principalTable: "MeasurementKeys",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Aquarium",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_Log",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurement_MeasurementKey",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_LogId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_MeasurementKeyId",
                table: "Measurements");
        }
    }
}
