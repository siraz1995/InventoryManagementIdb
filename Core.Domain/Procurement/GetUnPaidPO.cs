using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Procurement
{
    public class GetUnPaidPO
    {
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string VendorName { get; set; }
        public string ShopName { get; set; }
        public string NetTotal { get; set; }
        public bool IsPaid { get; set; }
    }
}
