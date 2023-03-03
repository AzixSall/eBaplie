using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBaplie.Data.Migrations
{
    public partial class BaplieAndRequirementsRelatedToVoyageAndAddActiveStateInEdi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EdifactGlobals_BaplieRequirements_BaplieRequirementNavigationId",
                table: "EdifactGlobals");

            migrationBuilder.DropForeignKey(
                name: "FK_EdifactGlobals_Vessels_VesselId",
                table: "EdifactGlobals");

            migrationBuilder.DropIndex(
                name: "IX_EdifactGlobals_BaplieRequirementNavigationId",
                table: "EdifactGlobals");

            migrationBuilder.DropColumn(
                name: "BaplieRequirementNavigationId",
                table: "EdifactGlobals");

            migrationBuilder.RenameColumn(
                name: "VesselId",
                table: "EdifactGlobals",
                newName: "VoyageId");

            migrationBuilder.RenameColumn(
                name: "RequirementId",
                table: "EdifactGlobals",
                newName: "BaplieRequirementId");

            migrationBuilder.RenameIndex(
                name: "IX_EdifactGlobals_VesselId",
                table: "EdifactGlobals",
                newName: "IX_EdifactGlobals_VoyageId");

            migrationBuilder.AddColumn<int>(
                name: "BaplieRequirementNavigationId",
                table: "Voyage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequirementId",
                table: "Voyage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "EdifactGlobals",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voyage_BaplieRequirementNavigationId",
                table: "Voyage",
                column: "BaplieRequirementNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_EdifactGlobals_BaplieRequirementId",
                table: "EdifactGlobals",
                column: "BaplieRequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_EdifactGlobals_BaplieRequirements_BaplieRequirementId",
                table: "EdifactGlobals",
                column: "BaplieRequirementId",
                principalTable: "BaplieRequirements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EdifactGlobals_Voyage_VoyageId",
                table: "EdifactGlobals",
                column: "VoyageId",
                principalTable: "Voyage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_BaplieRequirements_BaplieRequirementNavigationId",
                table: "Voyage",
                column: "BaplieRequirementNavigationId",
                principalTable: "BaplieRequirements",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EdifactGlobals_BaplieRequirements_BaplieRequirementId",
                table: "EdifactGlobals");

            migrationBuilder.DropForeignKey(
                name: "FK_EdifactGlobals_Voyage_VoyageId",
                table: "EdifactGlobals");

            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_BaplieRequirements_BaplieRequirementNavigationId",
                table: "Voyage");

            migrationBuilder.DropIndex(
                name: "IX_Voyage_BaplieRequirementNavigationId",
                table: "Voyage");

            migrationBuilder.DropIndex(
                name: "IX_EdifactGlobals_BaplieRequirementId",
                table: "EdifactGlobals");

            migrationBuilder.DropColumn(
                name: "BaplieRequirementNavigationId",
                table: "Voyage");

            migrationBuilder.DropColumn(
                name: "RequirementId",
                table: "Voyage");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "EdifactGlobals");

            migrationBuilder.RenameColumn(
                name: "VoyageId",
                table: "EdifactGlobals",
                newName: "VesselId");

            migrationBuilder.RenameColumn(
                name: "BaplieRequirementId",
                table: "EdifactGlobals",
                newName: "RequirementId");

            migrationBuilder.RenameIndex(
                name: "IX_EdifactGlobals_VoyageId",
                table: "EdifactGlobals",
                newName: "IX_EdifactGlobals_VesselId");

            migrationBuilder.AddColumn<int>(
                name: "BaplieRequirementNavigationId",
                table: "EdifactGlobals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EdifactGlobals_BaplieRequirementNavigationId",
                table: "EdifactGlobals",
                column: "BaplieRequirementNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EdifactGlobals_BaplieRequirements_BaplieRequirementNavigationId",
                table: "EdifactGlobals",
                column: "BaplieRequirementNavigationId",
                principalTable: "BaplieRequirements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EdifactGlobals_Vessels_VesselId",
                table: "EdifactGlobals",
                column: "VesselId",
                principalTable: "Vessels",
                principalColumn: "Id");
        }
    }
}
