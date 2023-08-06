using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Procurement.Purchase
{
    public class InvoiceHeader
    {

        public string InvoiceNo { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public string? VendorCode { get; set; }
        public string? ShopCode { get; set; }
        public string? Remarks { get; set; }
        public decimal? Total { get; set; }
        public decimal? Tax { get; set; }
        public decimal? NetTotal { get; set; }
        public bool IsPaid { get; set; }
    }
}
