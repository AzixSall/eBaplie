using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBaplie.Data.Migrations
{
    public partial class AddBaplieFileInVoyage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "BaplieFile",
                table: "Voyage",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaplieFile",
                table: "Voyage");
        }
    }
}
