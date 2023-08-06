using Core.Domain.Procurement.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Sales
{
    public class SalesInput
    {
        public string InvoiceNo { get; set; } = null!;
        public DateTime? InvoiceDate { get; set; }
        public string? ShopCode { get; set; }
        public string? CustomerName { get; set; }
        public int? MobileNo { get; set; }
        public string? Address { get; set; }
        public decimal? Total { get; set; }
        public decimal? Vat { get; set; }
        public decimal? NetTotal { get; set; }
        public List<SalesInfoDetails>? details { get; set; }
    }
}
