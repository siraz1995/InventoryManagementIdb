using System;
using System.Collections.Generic;

namespace Infrastructure.DBContext
{
    public partial class PurchaseOrederReturnHeader
    {
        public string InvoiceNo { get; set; } = null!;
        public DateTime? InvoiceDate { get; set; }
        public string? VendorCode { get; set; }
        public string? ShopCode { get; set; }
        public string? Remarks { get; set; }
        public decimal? Total { get; set; }
        public decimal? Tax { get; set; }
        public decimal? NetTotal { get; set; }
    }
}
