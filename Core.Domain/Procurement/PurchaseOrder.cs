using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Core.Domain.Procurement
{
    public class PurchaseOrder
    {
        public int? Id { get; set; }
        public string? InvoiceNo { get; set; }
        public string? SupplierCode { get; set; }
        public string? StoreCode { get; set; }
        public string? PurchaseOrderDate { get; set; }
        public string ItemName { get; set; }
        public string BrandCode { get; set; }
        public Core.Domain.Brand.Brand Brand { get; }
        public string CategoryCode { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string UnitTypeCode { get; set; }
        public bool? IsExpirable { get; set; }
        //public DateTime ExpiryDate { get; set; }
        public string Status { get; set; }
    }
}
