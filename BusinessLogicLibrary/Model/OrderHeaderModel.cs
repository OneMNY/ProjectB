using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Model
{
    public class OrderHeaderModel
    {
        public string RARefNum { get; set; }
        public string WMSRefNum { get; set; }
        public string Customer { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ExpShippedDate { get; set; }
        public DateTime? LastShippedDate { get; set; }
        public string CustomerOrderReference { get; set; }
        public string CustomerShipmentNo { get; set; }
        public string CustomerSONo { get; set; }
        public string CustomerInvoiceNo { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string TransportMode { get; set; }
        public string ShipmentNo { get; set; }
        public string DocumentNo { get; set; }
        public string CustomerReference1 { get; set; }
        public string CustomerReference2 { get; set; }
        public string ReferenceInfo1 { get; set; }
        public string ReferenceInfo2 { get; set; }
        public string ConsigneeId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public string CarrierId { get; set; }
        public string CarrierName { get; set; }
        public string CarrierAddress { get; set; }
    }
}
