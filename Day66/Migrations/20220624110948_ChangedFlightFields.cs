using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day66.Migrations
{
    public partial class ChangedFlightFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "Flights",
                newName: "ReturnDateTime");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "Flights",
                newName: "DepartureDateTime");

            migrationBuilder.AddColumn<int>(
                name: "PlaneModelRefId",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PricePerAdult",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneModelRefId",
                table: "Flights",
                column: "PlaneModelRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_PlaneModels_PlaneModelRefId",
                table: "Flights",
                column: "PlaneModelRefId",
                principalTable: "PlaneModels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_PlaneModels_PlaneModelRefId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PlaneModelRefId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PlaneModelRefId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PricePerAdult",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "ReturnDateTime",
                table: "Flights",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "DepartureDateTime",
                table: "Flights",
                newName: "ArrivalTime");
        }
    }
}
