using eBaplie.Models.Enums;

namespace eBaplie.Models
{
    public class EdifactGlobal
    {
        public string? Line { get; set; }
        public string? Line_To { get; set; }
        public DateTime? DateEDI { get; set; }
        public string? TypeEDI { get; set; }
        public Tero TransportEquipmentReleaseOrderEnum { get; set; }
        public string? DeliveryOrderNumber { get; set; }
        public string? BillOfLadingNumber { get; set; }
        public string? TransferNumber { get; set; }
        public string? VoyageNumber { get; set; }
        public string? PreviousMessageNumber { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? BookingNumber { get; set; }
        public string? ContainerSequenceNumber { get; set; }
        public string? MaritimeTransportMainCarriage { get; set; }
        public OnCarriageTransportMode OnCarriageTransportModeEnum { get; set; }
        public string? FreeText { get; set; }
        public string? SplitGoodsPlacement { get; set; }
        public string? Carrier { get; set; }
        public string? CarrierPartyName { get; set; }
        public string? CarrierStreetName { get; set; }
        public string? CarrierCityName { get; set; }
        public string? CustomsBroker { get; set; }
        public string? DryOrReefer { get; set; }
        public string? IMDGClass { get; set; }
        public int Volume { get; set; }
        public int Tare { get; set; }
        public int VGM { get; set; }
        public string? DestinataireShipTo { get; set; }
        public string? SenderMessage { get; set; }
        public string? SenderPartyName { get; set; }
        public string? SenderStreetName { get; set; }
        public string? SenderCityName { get; set; }
        public string? Consignee { get; set; }
        public string? ConsigneePartyName { get; set; }
        public string? ConsigneeStreetName { get; set; }
        public string? ConsigneeCityName { get; set; }
        public string? NAD_Shipto { get; set; }
        public string? NAD_MessageRecipient { get; set; }
        public string? NAD_PartyName { get; set; }
        public string? NAD_StreetName { get; set; }
        public string? NAD_CityName { get; set; }
        public string? ContainerID { get; set; }
        public string? TypeISO { get; set; }
        public string? Status { get; set; }
        public Status StatusEnum { get; set; }
        public string? Haulage { get; set; }
        public string? Measurement { get; set; }
        public string? Temperature { get; set; }
        public DateTime? ArrivalDateTimeEstimated { get; set; }
        public DateTime? DepartureDateTimeEstimated { get; set; }
        public DateTime? UltimateReleaseDateTime { get; set; }
        public DateTime? DepartureDateTimeReal { get; set; }
        public string? TotalNumberOfEquipment { get; set; }
        public string? PlaceOfReceipt { get; set; }
        public string? PlaceOfDelivery { get; set; }
        public string? PortOfLoading { get; set; }
        public string? PortOfDischarge { get; set; }
        public string? PortOfTransShipment { get; set; }
        public string? InformationContact { get; set; }
        public string? InformationContactName { get; set; }
        public string? InformationContactPhone { get; set; }
        public string? Dimension { get; set; }

        //BAPLIE
        public string? XPos { get; set; }
        public string? YPos { get; set; }
        public string? ZPos { get; set; }
    }
}
