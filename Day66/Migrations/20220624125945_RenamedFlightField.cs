using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day66.Migrations
{
    public partial class RenamedFlightField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnDateTime",
                table: "Flights",
                newName: "ArrivalDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArrivalDateTime",
                table: "Flights",
                newName: "ReturnDateTime");
        }
    }
}
