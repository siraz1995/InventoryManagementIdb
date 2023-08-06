using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Procurement
{
    public class PurchaseReturn
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string Supplier { get; set; }
        public string StoreName { get; set; }
        public DateTime PurchaseReturnDate { get; set; }
        public string ItemName { get; set; }
        public string BrandName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string UnitTypeName { get; set; }
        public string Status { get; set; }
    }
}
