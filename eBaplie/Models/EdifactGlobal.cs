using eBaplie.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace eBaplie.Models
{
    public class EdifactGlobal
    {
        public EdifactGlobal()
        {
            EdiChangeLogsNavigation = new HashSet<EdiChangeLog>();
        }

        public int Id { get; set; }
        public string? Line { get; set; }

        [Display(Name ="Line to")]
        public string? Line_To { get; set; }

        [Display(Name = "Date EDI")]
        public DateTime? DateEDI { get; set; }

        [Display(Name = "Type EDI")]
        public string? TypeEDI { get; set; }

        [Display(Name = "TERO")]
        public Tero TransportEquipmentReleaseOrderEnum { get; set; }

        [Display(Name = "# DO")]
        public string? DeliveryOrderNumber { get; set; }

        [Display(Name = "# BL")]
        public string? BillOfLadingNumber { get; set; }

        [Display(Name = "# Transfer")]
        public string? TransferNumber { get; set; }

        [Display(Name = "# Voyage")]
        public string? VoyageNumber { get; set; }

        [Display(Name = "# Previous Message")]
        public string? PreviousMessageNumber { get; set; }

        [Display(Name = "# Reference")]
        public string? ReferenceNumber { get; set; }

        [Display(Name = "BN")]
        public string? BookingNumber { get; set; }

        [Display(Name = "# Container Sequence")]
        public string? ContainerSequenceNumber { get; set; }

        [Display(Name = "Martitime Transport")]
        public string? MaritimeTransportMainCarriage { get; set; }

        [Display(Name = "Carriage Mode")]
        public OnCarriageTransportMode OnCarriageTransportModeEnum { get; set; }

        [Display(Name = "FT")]
        public string? FreeText { get; set; }

        [Display(Name = "Split Goods Placement")]
        public string? SplitGoodsPlacement { get; set; }
        public string? Carrier { get; set; }

        [Display(Name = "Carrier Party")]
        public string? CarrierPartyName { get; set; }

        [Display(Name = "Carrier Street")]
        public string? CarrierStreetName { get; set; }

        [Display(Name = "Carier City")]
        public string? CarrierCityName { get; set; }

        [Display(Name = "Customs")]
        public string? CustomsBroker { get; set; }

        [Display(Name = "Dry/Reefer")]
        public string? DryOrReefer { get; set; }

        [Display(Name = "IMDG")]
        public string? IMDGClass { get; set; }

        [Display(Name = "Volume")]
        public int Volume { get; set; }

        [Display(Name = "Tare")]
        public int Tare { get; set; }

        [Display(Name = "VGM")]
        public int VGM { get; set; }

        [Display(Name = "Desti. Ship to")]
        public string? DestinataireShipTo { get; set; }

        [Display(Name = "Sender Message")]
        public string? SenderMessage { get; set; }

        [Display(Name = "Sender Party")]
        public string? SenderPartyName { get; set; }

        [Display(Name = "Sender Street")]
        public string? SenderStreetName { get; set; }

        [Display(Name = "Sender City")]
        public string? SenderCityName { get; set; }

        public string? Consignee { get; set; }

        [Display(Name = "Consignee Party")]
        public string? ConsigneePartyName { get; set; }

        [Display(Name = "Consignee Street")]
        public string? ConsigneeStreetName { get; set; }

        [Display(Name = "Consginee City")]
        public string? ConsigneeCityName { get; set; }

        [Display(Name = "NAD Ship To")]
        public string? NAD_Shipto { get; set; }

        [Display(Name = "NAD Message")]
        public string? NAD_MessageRecipient { get; set; }

        [Display(Name = "NAD Party")]
        public string? NAD_PartyName { get; set; }

        [Display(Name = "NAD Street")]
        public string? NAD_StreetName { get; set; }

        [Display(Name = "NAD City")]
        public string? NAD_CityName { get; set; }

        [Display(Name = "Container ID")]
        public string? ContainerID { get; set; }

        [Display(Name = "ISO Type")]
        public string? TypeISO { get; set; }

        [Display(Name = "Status")]
        public string? Status { get; set; }

        [Display(Name = "Status")]
        public Status StatusEnum { get; set; }

        public string? Haulage { get; set; }

        public string? Measurement { get; set; }

        public string? Temperature { get; set; }

        [Display(Name = "ETA")]
        public DateTime? ArrivalDateTimeEstimated { get; set; }

        [Display(Name = "ETD")]
        public DateTime? DepartureDateTimeEstimated { get; set; }

        [Display(Name = "Ultimate Release Date")]
        public DateTime? UltimateReleaseDateTime { get; set; }

        [Display(Name = "Real Departure Date")]
        public DateTime? DepartureDateTimeReal { get; set; }

        [Display(Name = "# Total equip.")]
        public string? TotalNumberOfEquipment { get; set; }

        [Display(Name = "Place of Receipt")]
        public string? PlaceOfReceipt { get; set; }

        [Display(Name = "Place of Delivery")]
        public string? PlaceOfDelivery { get; set; }

        [Display(Name = "Port of Loading")]
        public string? PortOfLoading { get; set; }

        [Display(Name = "Port of discharge")]
        public string? PortOfDischarge { get; set; }

        [Display(Name = "Port of trans-shipment")]
        public string? PortOfTransShipment { get; set; }

        [Display(Name = "Information Contact")]
        public string? InformationContact { get; set; }

        [Display(Name = "Contact Name")]
        public string? InformationContactName { get; set; }

        [Display(Name = "Contact Phone")]
        public string? InformationContactPhone { get; set; }

        [Display(Name = "Dimensions")]
        public string? Dimension { get; set; }

        //BAPLIE
        [Display(Name = "Row")]
        public string? XPos { get; set; }

        [Display(Name = "Tier")]
        public string? YPos { get; set; }

        [Display(Name = "Bay")]
        public string? ZPos { get; set; }
        public bool? Baplie { get; set; }

        [Display(Name = "Voyage")]
        public int? VoyageId { get; set; }

        public bool? Active { get; set; }

        public bool? IsUnderDeck { get; set; }

        //Virtual
        [Display(Name = "Voyage")]
        public virtual Voyage? VoyageNavigation { get; set; }
        public virtual ICollection<EdiChangeLog>? EdiChangeLogsNavigation { get; set; }
    }
}
