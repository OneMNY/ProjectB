using AutoMapper;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace BusinessLogicLibrary.Model
{
    [XmlRoot(ElementName = "WMS")]
    public class OrderWrapperXmlDto
    {
        public OrderDto Order { get; set; }
    }

    public class OrderDto
    {
        public OrderHeaderDto Header { get; set; }
        public List<OrderDetailDto> Details { get; set; }
    }

    public class OrderHeaderDto
    {
        private string _dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        public string RARefNum { get; set; } = "";

        [XmlElement(ElementName = "WMSCategory")]
        public string Customer { get; set; } = "";

        [XmlElement(ElementName = "CustomerID")]
        public string SupplierName { get; set; } = "";

        [XmlIgnore]
        public DateTime? CreationDate { get; set; }

        [XmlElement(ElementName = "CreationDate")]
        public string CreationDateProxy 
        {
            get { return CreationDate.HasValue ? CreationDate.Value.ToString(_dateTimeFormat) : ""; }
            set { CreationDate = DateTime.Parse(value); } 
        }

        [XmlIgnore]
        public DateTime? OrderDate { get; set; }

        [XmlElement(ElementName = "OrderDate")]
        public string OrderDateProxy
        {
            get { return OrderDate.HasValue ? OrderDate.Value.ToString(_dateTimeFormat) : ""; }
            set { OrderDate = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public DateTime? ExpShippedDate { get; set; }

        [XmlElement(ElementName = "ExpectedShippedDate")]
        public string ExpShippedDateProxy
        {
            get { return ExpShippedDate.HasValue ? ExpShippedDate.Value.ToString(_dateTimeFormat) : ""; }
            set { ExpShippedDate = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public DateTime? LastShippedDate { get; set; }

        [XmlElement(ElementName = "LastShippedDate")]
        public string LastShippedDateProxy
        {
            get { return LastShippedDate.HasValue ? LastShippedDate.Value.ToString(_dateTimeFormat) : ""; }
            set { LastShippedDate = DateTime.Parse(value); }
        }

        public string CustomerOrderReference { get; set; } = "";
        public string CustomerShipmentNo { get; set; } = "";
        public string CustomerSONo { get; set; } = "";
        public string CustomerInvoiceNo { get; set; } = "";
        public string CustomerReference1 { get; set; } = "";
        public string CustomerReference2 { get; set; } = "";

        [XmlElement(ElementName = "WMSReference1")]
        public string ReferenceInfo1 { get; set; } = "";

        [XmlElement(ElementName = "WMSReference2")]
        public string ReferenceInfo2 { get; set; } = "";
        public string ShipmentNo { get; set; } = "";
        public string DocumentNo { get; set; } = "";
        public TransportationDto Transportation { get; set; } = new TransportationDto();
        public CarrierDto Carrier { get; set; } = new CarrierDto();
        public ConsigneeDto Consignee { get; set; } = new ConsigneeDto();
        public string Containers { get; set; } = "";
    }

    public class TransportationDto
    {
        public string Mode { get; set; } = "";
        public string VehicleType { get; set; } = "";
    }

    public class CarrierDto
    {
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Country { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public ContactDto Contact { get; set; } = new ContactDto();
    }

    public class ContactDto
    {
        public string Sequence { get; set; } = "";
        public string Person { get; set; } = "";
        public string Email { get; set; } = "";
        public string DID { get; set; } = "";
        public string Handphone { get; set; } = "";
    }

    public class ConsigneeDto
    {
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Country { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public ContactDto Contact { get; set; } = new ContactDto();
    }

    [XmlType(TypeName = "Detail")]
    [XmlRoot(ElementName = "Detail")]
    public class OrderDetailDto
    {
        private string _dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        [XmlElement("LineNo")]
        public int RARefLine { get; set; }
        public string SKU { get; set; } = "";
        public string SKUDescription { get; set; } = "";
        public string Package { get; set; } = "";

        [XmlIgnore]
        public double OrderedQty { get; set; }

        [XmlElement(ElementName = "OrderedQty")]
        public string FormattedOrderedQty
        {
            get { return OrderedQty.ToString("0.000"); }
            set { OrderedQty = double.Parse(value); }
        }

        [XmlIgnore]
        public double PickedQty { get; set; }

        [XmlElement(ElementName = "PickedQty")]
        public string FormattedPickedQty
        {
            get { return PickedQty.ToString("0.000"); }
            set { PickedQty = double.Parse(value); }
        }

        [XmlIgnore]
        public DateTime? PickedDate { get; set; }

        [XmlElement(ElementName = "PickedDate")]
        public string PickedDateProxy
        {
            get { return PickedDate.HasValue ? PickedDate.Value.ToString(_dateTimeFormat) : ""; }
            set { PickedDate = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public double ShippedQty { get; set; }

        [XmlElement(ElementName = "ShippedQty")]
        public string FormattedShippedQty
        {
            get { return ShippedQty.ToString("0.000"); }
            set { ShippedQty = double.Parse(value); }
        }

        [XmlIgnore]
        public DateTime? ShippedDate { get; set; }

        [XmlElement(ElementName = "ShippedDate")]
        public string ShippedDateProxy
        {
            get { return ShippedDate.HasValue ? ShippedDate.Value.ToString(_dateTimeFormat) : ""; }
            set { ShippedDate = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public DateTime? ManufactoryDate { get; set; }

        [XmlElement(ElementName = "ManufactoryDate")]
        public string ManufactoryDateProxy
        {
            get { return ManufactoryDate.HasValue ? ManufactoryDate.Value.ToString(_dateTimeFormat) : ""; }
            set { ManufactoryDate = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public DateTime? ExpiryDate { get; set; }

        [XmlElement(ElementName = "ExpiryDate")]
        public string ExpiryDateProxy
        {
            get { return ExpiryDate.HasValue ? ExpiryDate.Value.ToString(_dateTimeFormat) : ""; }
            set { ExpiryDate = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public DateTime? FIFODate { get; set; }

        [XmlElement(ElementName = "FIFODate")]
        public string FIFODateProxy
        {
            get { return FIFODate.HasValue ? FIFODate.Value.ToString(_dateTimeFormat) : ""; }
            set { FIFODate = DateTime.Parse(value); }
        }

        [XmlElement(ElementName = "CustomerLotRef1")]
        public string ReferenceInfo1 { get; set; } = "";

        [XmlElement(ElementName = "CustomerLotRef2")]
        public string ReferenceInfo2 { get; set; } = "";

        [XmlElement(ElementName = "LineReference1")]
        public string QACode { get; set; } = "";
    }
}
