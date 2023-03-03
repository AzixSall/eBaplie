using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBaplie.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaplieRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequireContainerSize = table.Column<bool>(type: "bit", nullable: true),
                    RequireContainerNumber = table.Column<bool>(type: "bit", nullable: true),
                    RequireContainerType = table.Column<bool>(type: "bit", nullable: true),
                    RequireVesselVoyagNumber = table.Column<bool>(type: "bit", nullable: true),
                    RequirePackagingDetails = table.Column<bool>(type: "bit", nullable: true),
                    RequireConsigneeDetails = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaplieRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EdifactGlobals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line_To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEDI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeEDI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportEquipmentReleaseOrderEnum = table.Column<int>(type: "int", nullable: false),
                    DeliveryOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillOfLadingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoyageNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviousMessageNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerSequenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritimeTransportMainCarriage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnCarriageTransportModeEnum = table.Column<int>(type: "int", nullable: false),
                    FreeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SplitGoodsPlacement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierPartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierStreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierCityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomsBroker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DryOrReefer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMDGClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: false),
                    Tare = table.Column<int>(type: "int", nullable: false),
                    VGM = table.Column<int>(type: "int", nullable: false),
                    DestinataireShipTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderPartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderStreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderCityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consignee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneePartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneeStreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsigneeCityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAD_Shipto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAD_MessageRecipient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAD_PartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAD_StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NAD_CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeISO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusEnum = table.Column<int>(type: "int", nullable: false),
                    Haulage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Measurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalDateTimeEstimated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureDateTimeEstimated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimateReleaseDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartureDateTimeReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalNumberOfEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfReceipt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfDelivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortOfLoading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortOfDischarge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortOfTransShipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformationContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformationContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformationContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XPos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YPos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZPos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Baplie = table.Column<bool>(type: "bit", nullable: true),
                    VesselId = table.Column<int>(type: "int", nullable: true),
                    RequirementId = table.Column<int>(type: "int", nullable: true),
                    BaplieRequirementNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdifactGlobals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdifactGlobals_BaplieRequirements_BaplieRequirementNavigationId",
                        column: x => x.BaplieRequirementNavigationId,
                        principalTable: "BaplieRequirements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EdifactGlobals_Vessels_VesselId",
                        column: x => x.VesselId,
                        principalTable: "Vessels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EdiChangeLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdifactId = table.Column<int>(type: "int", nullable: false),
                    ChangeType = table.Column<int>(type: "int", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EdifactNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdiChangeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdiChangeLogs_EdifactGlobals_EdifactNavigationId",
                        column: x => x.EdifactNavigationId,
                        principalTable: "EdifactGlobals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EdiChangeLogs_EdifactNavigationId",
                table: "EdiChangeLogs",
                column: "EdifactNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_EdifactGlobals_BaplieRequirementNavigationId",
                table: "EdifactGlobals",
                column: "BaplieRequirementNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_EdifactGlobals_VesselId",
                table: "EdifactGlobals",
                column: "VesselId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdiChangeLogs");

            migrationBuilder.DropTable(
                name: "EdifactGlobals");

            migrationBuilder.DropTable(
                name: "BaplieRequirements");

            migrationBuilder.DropTable(
                name: "Vessels");
        }
    }
}
