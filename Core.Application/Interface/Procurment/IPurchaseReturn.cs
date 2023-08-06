using Core.Domain.Procurement.Purchase;
using Core.Domain.Procurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Procurment
{
    public interface IPurchaseReturn
    {
        Task<ResponseType> Save(InvoiceInput invoiceEntity);
        Task<List<InvoiceHeader>> GetPurchaseOrderReturnHeaderList();
        Task<InvoiceHeader> GetPurchaseOrderReturnHeaderByInvoice(string invoiceNo);
        Task<List<InvoiceDetail>> GetPurchaseOrderReturnDetailsByInvoice(string invoiceNo);
        Task<ResponseType> Remove(string invoiceNo);
        Task<PurchaseOrderReport> GetPurchaseOrderReturnHeaderForReport(string invoiceNo);
        Task<List<PurchaseOrderReport>> GetPurchaseOrderReturnDetailsForReport(string invoiceNo);
    }
}
