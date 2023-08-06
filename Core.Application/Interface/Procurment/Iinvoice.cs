using Core.Domain.Procurement;
using Core.Domain.Procurement.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Procurment
{
    public interface Iinvoice
    {
        Task<ResponseType> Save(InvoiceInput invoiceEntity);
        Task<List<InvoiceHeader>> GetPurchaseOrderHeaderList();
        Task<InvoiceHeader> GetPurchaseOrderHeaderByInvoice(string invoiceNo);
        Task<List<InvoiceDetail>> GetPurchaseOrderDetailsByInvoice(string invoiceNo);
        Task<ResponseType> Remove(string invoiceNo);
        Task<PurchaseOrderReport> GetPurchaseOrderHeaderForReport(string invoiceNo);
        Task<List<PurchaseOrderReport>> GetPurchaseOrderDetailsForReport(string invoiceNo);

    }
}
