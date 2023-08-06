using System;
using System.Collections.Generic;

namespace Infrastructure.DBContext
{
    public partial class SalesReturnDetail
    {
        public string InvoiceNo { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public string? UnitTypeCode { get; set; }
        public string? Discription { get; set; }
        public int? Quantity { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? Total { get; set; }
    }
}
