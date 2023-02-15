using eBaplie.Models;
using eBaplie.Models.Enums;

namespace eBaplie.Helpers
{
    public class Parser
    {
        public static BaplieData ProcessFileSegments(string edifactText)
        {
            {
                try
                {
                    var helpers = new ParserHelper();

                    int count = 0;

                    List<EdifactGlobal> listedifact = new List<EdifactGlobal>();
                    List<Port> ports = new List<Port>();

                    //on recupere un tableau de segments
                    string[] tabSegment = helpers.GetSegments(edifactText);

                    EdifactGlobal edifact = new EdifactGlobal();

                    for (var i = 0; i < tabSegment.Length; i++)
                    {
                        //on recupere un tableau d'elements dans chaque segment
                        string[] elem = helpers.GetElements(tabSegment[i]);

                        for (var j = 0; j < elem.Length; j++)
                        {
                            elem[j] = elem[j].Replace("\n", String.Empty);
                            elem[j] = elem[j].Replace("\r", String.Empty);

                            try
                            {
                                if (elem[j] == "UNB")
                                {
                                    edifact.Line = elem[2];
                                    edifact.Line_To = elem[3];
                                    edifact.DateEDI = helpers.Convert2DateTime(elem[4]); //200618:1220
                                }

                                if (elem[j] == "UNH")
                                {
                                    count++;
                                    edifact.TypeEDI = elem[2];
                                }

                                if (elem[j] == "BGM")
                                {

                                    switch (elem[3])
                                    {
                                        case "1":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.Cancellation;
                                            break;

                                        case "2":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.Addition;
                                            break;

                                        case "3":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.Deletion;
                                            break;

                                        case "4":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.Change;
                                            break;

                                        case "5":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.Replace;
                                            break;

                                        case "9":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.Original;
                                            break;

                                        case "22":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.Final;
                                            break;

                                        case "31":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.CopyInformationThirdParty;
                                            break;

                                        case "33":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.ChangeHeaderSection;
                                            break;

                                        case "36":
                                            edifact.TransportEquipmentReleaseOrderEnum = Tero.ChangeDetailSection;
                                            break;
                                    }
                                }

                                if (elem[j] == "RFF")
                                {

                                    string[] rff = helpers.GetComponent(elem[j + 1]);

                                    switch (rff[0])
                                    {
                                        case "REO":
                                            edifact.DeliveryOrderNumber = rff[1];
                                            break;

                                        case "BN":
                                            edifact.BookingNumber = rff[1];
                                            listedifact.Add(edifact);
                                            edifact = new EdifactGlobal();
                                            break;
                                        case "BM":
                                            edifact.BookingNumber = rff[1];
                                            listedifact.Add(edifact);
                                            edifact = new EdifactGlobal();
                                            break;

                                        case "TF":
                                            edifact.TransferNumber = rff[1];
                                            break;

                                        case "VON":
                                            edifact.VoyageNumber = rff[1];
                                            break;

                                        case "ACW":
                                            edifact.PreviousMessageNumber = rff[1];
                                            break;

                                        case "ACD":
                                            edifact.ReferenceNumber = rff[1];
                                            break;

                                        case "SQ":
                                            edifact.PreviousMessageNumber = rff[1];
                                            break;
                                    }
                                }

                                if (elem[j] == "TDT")
                                {
                                    //TDT+20+0LA20E1PL+1++CMA:172:ZZZ+++9V2229:103::THALASSA PATRIS:SG
                                    //TDT+20+151W+1++HLC:172:166+++ELXZ3:103::YM GREEN

                                    if (elem[j + 1] == "20")
                                    {
                                        edifact.Line = elem[j + 5].Split(char.Parse(":"))[0];
                                        string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                        edifact.MaritimeTransportMainCarriage = tab[0];
                                        edifact.VoyageNumber = elem[j + 2];
                                    }
                                    //TDT+30++3
                                    if (elem[j + 1] == "30")
                                    {
                                        switch (elem[3])
                                        {
                                            case "2":
                                                edifact.OnCarriageTransportModeEnum = OnCarriageTransportMode.Rail;
                                                break;

                                            case "3":
                                                edifact.OnCarriageTransportModeEnum = OnCarriageTransportMode.Road;
                                                break;

                                            case "8":
                                                edifact.OnCarriageTransportModeEnum = OnCarriageTransportMode.InlandWater;
                                                break;

                                            case "9":
                                                edifact.OnCarriageTransportModeEnum = OnCarriageTransportMode.Unknown;
                                                break;
                                        }
                                    }
                                }

                                if (elem[j] == "FTX")
                                {

                                    if (elem[j + 1] == "AAI" || elem[j + 1] == "AAA")
                                    {
                                        edifact.FreeText = elem[elem.Length - 1];
                                    }
                                    else
                                    {
                                        edifact.FreeText = elem[elem.Length - 1];
                                    }
                                }

                                if (elem[j] == "SGP")
                                {
                                    string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                    edifact.SplitGoodsPlacement = tab[0];
                                }

                                if (elem[j] == "NAD")
                                {
                                    switch (elem[1])
                                    {
                                        case "CA":
                                            if (elem.Length <= 3)
                                            {
                                                string[] nad = helpers.GetComponent(elem[j + 2]);
                                                edifact.Carrier = nad[0];
                                            }
                                            else
                                            {
                                                edifact.CarrierPartyName = elem[j + 4];
                                                edifact.CarrierStreetName = elem[j + 5];
                                                edifact.CarrierCityName = elem[j + 6];
                                                //NAD+CA+++Thomas Transport Company+P.0.Box 8013+LONDON1
                                            }
                                            break;

                                        case "CB":
                                            string[] cb = helpers.GetComponent(elem[j + 2]);
                                            edifact.CustomsBroker = cb[0] + " Carrier internal customer";
                                            break;

                                        case "ST":
                                            edifact.DestinataireShipTo = elem[j + 2];
                                            break;

                                        case "MS":
                                            if (elem.Length <= 3)
                                            {
                                                edifact.NAD_MessageRecipient = elem[j + 2];
                                            }
                                            else
                                            {
                                                edifact.NAD_PartyName = elem[elem.Length - 3];
                                                edifact.NAD_StreetName = elem[elem.Length - 2];
                                                edifact.NAD_CityName = elem[elem.Length - 1];
                                            }
                                            break;

                                        case "CN":
                                            //NAD+CN+GOLDEN LIGHT TRADING+++MEAIZAR. UM ALDOM ST+DOHA
                                            edifact.ConsigneePartyName = elem[j + 2];
                                            edifact.ConsigneeStreetName = elem[j + 5];
                                            edifact.ConsigneeCityName = elem[j + 6];
                                            break;

                                        case "BS":
                                            edifact.Consignee = elem[j + 2];
                                            break;

                                        case "MR":
                                            //NAD+MR+QTERMINAL LLC::ZZZ++QTERMINAL LLC++DOHA
                                            edifact.NAD_PartyName = elem[j + 4];
                                            edifact.NAD_CityName = elem[j + 6];
                                            break;

                                        case "EO":
                                            edifact.NAD_Shipto = elem[j + 5];
                                            break;
                                    }
                                }

                                if (elem[j] == "EQD")
                                {
                                    string[] eqd = helpers.GetComponent(elem[j + 3]);

                                    switch (elem[5])
                                    {
                                        case "1":
                                            if (elem[6] == "5")
                                            {
                                                edifact.ContainerID = elem[2];
                                                edifact.TypeISO = eqd[0];
                                                edifact.Status = "Continental";
                                                edifact.StatusEnum = Status.Full;
                                            }
                                            if (elem[6] == "4")
                                            {
                                                edifact.ContainerID = elem[2];
                                                edifact.TypeISO = eqd[0];
                                                edifact.Status = "Continental";
                                                edifact.StatusEnum = Status.Empty;
                                            }

                                            break;

                                        case "2":

                                            if (elem[6] == "5")
                                            {
                                                edifact.ContainerID = elem[2];
                                                edifact.TypeISO = eqd[0];
                                                edifact.Status = "Export";
                                                edifact.StatusEnum = Status.Full;
                                            }
                                            if (elem[6] == "4")
                                            {
                                                edifact.ContainerID = elem[2];
                                                edifact.TypeISO = eqd[0];
                                                edifact.Status = "Export";
                                                edifact.StatusEnum = Status.Empty;
                                            }
                                            break;

                                        case "3":

                                            if (elem[6] == "5")
                                            {
                                                edifact.ContainerID = elem[2];
                                                edifact.TypeISO = eqd[0];
                                                edifact.Status = "Import";
                                                edifact.StatusEnum = Status.Full;
                                            }
                                            if (elem[6] == "4")
                                            {
                                                edifact.ContainerID = elem[2];
                                                edifact.TypeISO = eqd[0];
                                                edifact.Status = "Import";
                                                edifact.StatusEnum = Status.Empty;
                                            }
                                            break;

                                        case "6":

                                            if (elem[6] == "5")
                                            {
                                                edifact.ContainerID = elem[2];
                                                edifact.TypeISO = eqd[0];
                                                edifact.Status = "Transhipment";
                                                edifact.StatusEnum = Status.Full;
                                            }
                                            if (elem[6] == "4")
                                            {
                                                edifact.ContainerID = elem[2];
                                                edifact.TypeISO = eqd[0];
                                                edifact.Status = "Transhipment";
                                                edifact.StatusEnum = Status.Empty;
                                            }
                                            break;
                                    }

                                    if (!string.IsNullOrEmpty(eqd[0]))
                                    {
                                        try
                                        {
                                            var typeRef = eqd[0].Substring(2, 1);
                                            if (!string.IsNullOrEmpty(typeRef))
                                            {
                                                switch (typeRef)
                                                {
                                                    case "R":
                                                        edifact.DryOrReefer = "RE";
                                                        break;
                                                    case "G":
                                                        edifact.DryOrReefer = "DR";
                                                        break;
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            edifact.DryOrReefer = "N/A";
                                        }
                                    }
                                }

                                if (elem[j] == "TSR")
                                {
                                    if (elem[1] == "27")
                                    {
                                        edifact.Carrier = "Carrier Haulage (Door-to-door)";
                                    }
                                    if (elem[1] == "30")
                                    {
                                        edifact.Carrier = "Merchant Haulage (Pier-to-pier)";
                                    }
                                }

                                if (elem[j] == "MEA")
                                {
                                    /*
                                     MEA+AAE+VGM+KGM:33300'
                                     MEA+AAE+T+KGM:4600'
                                     MEA+AAE+AAW+MTQ:50'*/
                                    if (elem.Length >= 4)
                                    {
                                        if (elem[j + 2] == "VGM")
                                        {
                                            string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                            edifact.VGM = Int32.Parse(tab[1]);
                                        }
                                        else if (elem[j + 2] == "T")
                                        {
                                            string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                            edifact.Tare = Int32.Parse(tab[1]);
                                        }
                                        else if (elem[j + 2] == "AAW")
                                        {
                                            string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                            edifact.Volume = Int32.Parse(tab[1]);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                                edifact.Measurement = tab[1] + " " + tab[0];
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }

                                    }
                                }

                                if (elem[j] == "TMP")
                                {
                                    if (elem.Length >= 3)
                                    {
                                        string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                        try
                                        {
                                            string[] floatTemp = tab[0].Split(char.Parse("."));
                                            int temp = Int32.Parse(floatTemp[0]);
                                            if (tab[1].ToLower() == "fah")
                                            {
                                                temp = (temp - 32) * 5 / 9;
                                            }
                                            edifact.Temperature = temp.ToString();
                                        }
                                        catch (Exception)
                                        {
                                            int temp = Int32.Parse(tab[0]);
                                            if (tab[1].ToLower() == "fah")
                                            {
                                                temp = (temp - 32) * 5 / 9;
                                            }
                                            edifact.Temperature = temp.ToString();
                                        }
                                    }
                                }

                                if (elem[j] == "DTM")
                                {
                                    string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));

                                    switch (tab[0])
                                    {
                                        case "132":
                                            edifact.ArrivalDateTimeEstimated = helpers.ConvertDateTime(tab[1]);
                                            break;

                                        case "133":
                                            edifact.DepartureDateTimeEstimated = helpers.ConvertDateTime(tab[1]);
                                            break;

                                        case "400":
                                            edifact.UltimateReleaseDateTime = helpers.ConvertDateTime(tab[1]);
                                            break;

                                        case "186":
                                            edifact.DepartureDateTimeReal = helpers.ConvertDateTime(tab[1]);
                                            break;
                                    }
                                }

                                if (elem[j] == "CNT")
                                {
                                    string[] cnt = helpers.GetComponent(elem[j + 1]);
                                    edifact.TotalNumberOfEquipment = cnt[0];
                                }

                                if (elem[j] == "LOC")
                                {
                                    // LOC+147+0080286::5
                                    if (elem[j + 1] == "147")
                                    {
                                        if (elem.Length <= 3)
                                        {
                                            var bayloc = elem[j + 2];
                                            edifact.XPos = bayloc.Substring(1, 2);
                                            edifact.ZPos = bayloc.Substring(3, 2);
                                            if (Int32.Parse(bayloc.Substring(5, 2)) >= 80)
                                            {
                                                edifact.YPos = (Int32.Parse(bayloc.Substring(5, 2)) - 80).ToString();
                                            }
                                            else
                                            {
                                                edifact.YPos = bayloc.Substring(5, 2);
                                            }

                                        }
                                    }

                                    if (elem[j + 1] == "7")
                                    {
                                        if (elem.Length > 3)
                                        {
                                            string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                            if (tab.Length <= 3)
                                            {
                                                edifact.PlaceOfDelivery = tab[0];
                                            }
                                            else
                                            {
                                                edifact.PlaceOfDelivery = tab[tab.Length - 1];
                                            }
                                        }

                                        if (elem.Length <= 3)
                                        {
                                            string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                            edifact.PlaceOfDelivery = tab[0];
                                        }
                                    }

                                    if (elem[j + 1] == "88" || elem[j + 1] == "8")
                                    {
                                        // LOC+88+MXZLO:139:6+CON:BER::CONTECON MANZANILLO S.A DE C.V.
                                        // LOC + 88 + SNDKR:139:6 + SNDKRDPW:TER: ZZZ
                                        // LOC+88+QAHMD:139:6

                                        if (elem.Length > 3)
                                        {
                                            string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                            if (tab.Length <= 3)
                                            {
                                                edifact.PlaceOfReceipt = tab[0];
                                            }
                                            else
                                            {
                                                edifact.PlaceOfReceipt = tab[tab.Length - 1];
                                            }
                                        }

                                        if (elem.Length <= 3)
                                        {
                                            string[] tab = elem[elem.Length - 1].Split(char.Parse(":"));
                                            edifact.PlaceOfReceipt = tab[0];
                                        }
                                    }

                                    if (elem[j + 1] == "9")
                                    {
                                        //LOC+9+LKCMB:139:6:COLOMBO
                                        //LOC+9+CNSHA:139:6'

                                        if (elem.Length > 4)
                                        {
                                            string[] tab1 = elem[elem.Length - 3].Split(char.Parse(":"));

                                            if (tab1.Length > 3)
                                            {
                                                edifact.PortOfLoading = tab1[3];
                                            }

                                            if (tab1.Length <= 3)
                                            {
                                                edifact.PortOfLoading = tab1[0];
                                            }

                                        }
                                        else if (elem.Length == 4)
                                        {
                                            string[] tab1 = elem[elem.Length - 2].Split(char.Parse(":"));

                                            if (tab1.Length > 3)
                                            {
                                                edifact.PortOfLoading = tab1[3];
                                            }

                                            if (tab1.Length <= 3)
                                            {
                                                edifact.PortOfLoading = tab1[0];
                                            }
                                        }
                                        else
                                        {
                                            string[] tab1 = elem[elem.Length - 1].Split(char.Parse(":"));

                                            if (tab1.Length > 3)
                                            {
                                                edifact.PortOfLoading = tab1[3];
                                            }

                                            if (tab1.Length <= 3)
                                            {
                                                edifact.PortOfLoading = tab1[0];
                                            }
                                        }

                                    }

                                    if (elem[j + 1] == "11")
                                    {

                                        if (elem.Length > 4)
                                        {
                                            string[] tab2 = elem[elem.Length - 1].Split(char.Parse(":"));

                                            if (tab2.Length > 3)
                                            {
                                                edifact.PortOfDischarge = tab2[3];
                                            }

                                            if (tab2.Length <= 3)
                                            {
                                                edifact.PortOfDischarge = tab2[0];
                                            }

                                        }
                                        else if (elem.Length == 4)
                                        {
                                            string[] tab2 = elem[elem.Length - 2].Split(char.Parse(":"));

                                            if (tab2.Length > 3)
                                            {
                                                edifact.PortOfDischarge = tab2[3];
                                            }

                                            if (tab2.Length <= 3)
                                            {
                                                edifact.PortOfDischarge = tab2[0];
                                            }
                                        }
                                        else
                                        {
                                            string[] tab2 = elem[elem.Length - 1].Split(char.Parse(":"));

                                            if (tab2.Length > 3)
                                            {
                                                edifact.PortOfDischarge = tab2[3];
                                            }

                                            if (tab2.Length <= 3)
                                            {
                                                edifact.PortOfDischarge = tab2[0];
                                            }
                                        }
                                    }

                                    if (elem[j + 1] == "13")
                                    {
                                        //string[] tab2 = elem[elem.Length - 1].Split(char.Parse(":"));
                                        //edifact.PortOfTransShipment = tab2[0];

                                        if (elem.Length > 4)
                                        {
                                            string[] tab2 = elem[elem.Length - 1].Split(char.Parse(":"));

                                            if (tab2.Length > 3)
                                            {
                                                edifact.PortOfTransShipment = tab2[3];
                                            }

                                            if (tab2.Length <= 3)
                                            {
                                                edifact.PortOfTransShipment = tab2[0];
                                            }

                                        }
                                        else if (elem.Length == 4)
                                        {
                                            string[] tab2 = elem[elem.Length - 2].Split(char.Parse(":"));

                                            if (tab2.Length > 3)
                                            {
                                                edifact.PortOfTransShipment = tab2[3];
                                            }

                                            if (tab2.Length <= 3)
                                            {
                                                edifact.PortOfTransShipment = tab2[0];
                                            }
                                        }
                                        else
                                        {
                                            string[] tab2 = elem[elem.Length - 1].Split(char.Parse(":"));

                                            if (tab2.Length > 3)
                                            {
                                                edifact.PortOfTransShipment = tab2[3];
                                            }

                                            if (tab2.Length <= 3)
                                            {
                                                edifact.PortOfTransShipment = tab2[0];
                                            }
                                        }
                                    }

                                    Port delivery = new Port { Name = edifact.PlaceOfDelivery, PortType = PortType.PlaceDelivery };
                                    if (!ports.Any(x => x.Name == delivery.Name && x.PortType == delivery.PortType) && !string.IsNullOrEmpty(delivery.Name))
                                    {
                                        ports.Add(delivery);
                                    }

                                    Port charge = new Port { Name = edifact.PortOfLoading, PortType = PortType.Loading };
                                    if (!ports.Any(x => x.Name == charge.Name && x.PortType == charge.PortType) && !string.IsNullOrEmpty(charge.Name))
                                    {
                                        ports.Add(charge);
                                    }

                                    Port discharge = new Port { Name = edifact.PortOfDischarge, PortType = PortType.Discharge };
                                    if (!ports.Any(x => x.Name == discharge.Name && x.PortType == discharge.PortType) && !string.IsNullOrEmpty(discharge.Name))
                                    {
                                        ports.Add(discharge);
                                    }

                                    Port receipt = new Port { Name = edifact.PlaceOfReceipt, PortType = PortType.Receipt };
                                    if (!ports.Any(x => x.Name == receipt.Name && x.PortType == receipt.PortType) && !string.IsNullOrEmpty(receipt.Name))
                                    {
                                        ports.Add(receipt);
                                    }

                                    Port transhipement = new Port { Name = edifact.PortOfTransShipment, PortType = PortType.Transhipment };
                                    if (!ports.Any(x => x.Name == transhipement.Name && x.PortType == transhipement.PortType) && !string.IsNullOrEmpty(transhipement.Name))
                                    {
                                        ports.Add(transhipement);
                                    }

                                }

                                if (elem[j] == "CTA")
                                {
                                    if (elem.Length <= 3)
                                    {
                                        edifact.InformationContact = elem[elem.Length - 1];
                                    }
                                    else
                                    {
                                        string[] tabCTA = elem[elem.Length - 1].Split(char.Parse(":"));

                                        edifact.InformationContactName = tabCTA[1];
                                        edifact.InformationContactPhone = tabCTA[0];
                                    }
                                }

                                if (elem[j] == "DIM")
                                {
                                    //DIM+1+CMT:240:96:102’
                                    // 1  Gross dimensions D    5  Off-standard front D    6 Off-standard back D    7 Off-standard right D    8 Off-standard left D   10 External dimensions
                                    switch (elem[1])
                                    {
                                        case "1":
                                            edifact.Dimension = "Gross dimensions";
                                            break;

                                        case "5":
                                            edifact.Dimension = "Off-standard front";
                                            break;

                                        case "6":
                                            edifact.Dimension = "Off-standard back";
                                            break;

                                        case "7":
                                            edifact.Dimension = "Off-standard right";
                                            break;

                                        case "8":
                                            edifact.Dimension = "Off-standard left";
                                            break;

                                        case "10":
                                            edifact.Dimension = "External dimensions";
                                            break;
                                    }
                                }

                                if (elem[j] == "DGS")
                                {
                                    if (elem[j + 1] == "IMD")
                                    {
                                        edifact.IMDGClass = elem[j + 2];
                                    }
                                }

                                //if (elem[j] == "UNT") //FIN MESSAGE
                                //{
                                //    listedifact.Add(edifact);
                                //    edifact = new EdifactGlobal();
                                //}
                            }
                            catch (Exception e)
                            {

                                throw;
                            }

                            //if (elem[j] == "UNZ")
                            //{
                            //    //return listedifact;
                            //    //Console.WriteLine("\t  * NUMBER OF MESSAGES: " + count + "             *");
                            //}
                        }

                    }
                    BaplieData newBaplieData = new BaplieData();

                    newBaplieData.Containers = listedifact;
                    newBaplieData.Ports = ports;

                    return newBaplieData;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);

                    return null;
                }
            }
        }
    }
}
