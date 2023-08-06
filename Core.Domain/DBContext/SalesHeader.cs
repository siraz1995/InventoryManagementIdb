using System;
using System.Collections.Generic;

namespace Core.Domain.DBContext
{
    public partial class SalesHeader
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
    }
}
