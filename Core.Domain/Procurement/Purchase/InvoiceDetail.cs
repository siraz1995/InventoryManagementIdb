using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Procurement.Purchase
{
    public class InvoiceDetail
    {
        public string InvoiceNo { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public string? UnitTypeCode { get; set; }
        public string? Discription { get; set; }
        public int? Qty { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? Total { get; set; }

    }
}
