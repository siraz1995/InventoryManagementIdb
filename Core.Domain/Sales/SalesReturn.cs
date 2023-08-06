using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Sales
{
    public class SalesReturn
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string Customer { get; set; }
        public string StoreName { get; set; }
        public DateTime SalesReturnDate { get; set; }
        public string ItemName { get; set; }
        public string BrandName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string UnitTypeName { get; set; }
        public string Status { get; set; }
    }
}
