using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Sales
{
    public class SaleItemReport
    {
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhoneNo { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string CustomerAddress { get; set; }
        public decimal Total { get; set; }
        public decimal Vat { get; set; }
        public decimal NetTotal { get; set; }


        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string UnitTypeName { get; set; }
        public string Discription { get; set; }
        public int Quantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
