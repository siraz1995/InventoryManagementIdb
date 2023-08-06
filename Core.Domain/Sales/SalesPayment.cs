using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Sales
{
    public class SalesPayment
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime PaymentReceiveDate { get; set; }
        public decimal BillAmount { get; set; }
        public decimal ReceiveAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string PaymentReceiveNote { get; set; }
    }
}
