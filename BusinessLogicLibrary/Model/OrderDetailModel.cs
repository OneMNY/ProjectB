using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary.Model
{
    public class OrderDetailModel
    {
        public string RARefNum { get; set; }
        public int RARefLine { get; set; }
        public string SKU { get; set; }
        public string SKUDescription { get; set; }
        public string Package { get; set; }
        public double OrderedQty { get; set; }
        public double PickedQty { get; set; }
        public string PickedBy { get; set; }
        public DateTime? PickedDate { get; set; }
        public double ShippedQty { get; set; }
        public string ShippedBy { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime? ManufactoryDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? FIFODate { get; set; }
        public string QACode { get; set; }
        public string ReferenceInfo1 { get; set; }
        public string ReferenceInfo2 { get; set; }
    }
}
