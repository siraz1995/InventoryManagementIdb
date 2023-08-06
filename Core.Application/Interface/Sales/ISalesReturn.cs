using Core.Domain.Procurement.Purchase;
using Core.Domain.Procurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Sales;

namespace Core.Application.Interface.Sales
{
    public interface ISalesReturn
    {
        Task<ResponseType> Save(SalesInput invoiceEntity);
        Task<List<SalesInfoHeader>> GetAllInvoiceHeader();
        Task<SalesInfoHeader> GetAllInvoiceHeaderbyCode(string invoiceNo);
        Task<List<SalesInfoDetails>> GetAllInvoiceDetailbyCode(string invoiceNo);
        Task<ResponseType> Remove(string invoiceNo);
        Task<SaleItemReport> GetSaleItemReturnHeaderForReport(string invoiceNo);
        Task<List<SaleItemReport>> GetSaleItemReturnDetailsForReport(string invoiceNo);
    }
}
