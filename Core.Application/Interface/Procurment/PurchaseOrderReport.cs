using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Procurment
{
    public class PurchaseOrderReport
    {
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierPhone { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StorePhone { get; set; }
        public string Remarks { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal NetTotal { get; set; }
        public bool IsPaid { get; set; }


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
