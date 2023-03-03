using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBaplie.Data.Migrations
{
    public partial class AddvoyagestoVessel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Vessels",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Voyage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoygeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VesselId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voyage_Vessels_VesselId",
                        column: x => x.VesselId,
                        principalTable: "Vessels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voyage_VesselId",
                table: "Voyage",
                column: "VesselId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voyage");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Vessels");
        }
    }
}
