using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaLog.Migrations
{
    public partial class gaveMeasurementAnIdKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Meaurement",
                table: "Measurements");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Measurements",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Measurements",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_AquariumId",
                table: "Measurements",
                column: "AquariumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_AquariumId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Measurements");

            migrationBuilder.AddColumn<double>(
                name: "Meaurement",
                table: "Measurements",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements",
                columns: new[] { "AquariumId", "MeasurementKeyId", "LogId" });
        }
    }
}
