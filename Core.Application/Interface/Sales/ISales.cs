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
    public interface ISales
    {
        Task<ResponseType> Save(SalesInput invoiceEntity);
        Task<List<SalesInfoHeader>> GetSalesHeaderList();

        Task<SalesInfoHeader> GeSalesHeaderByInvoice(string invoiceNo);
        Task<List<SalesInfoDetails>> GetSalesDetailsByInvoice(string invoiceNo);
        Task<ResponseType> Remove(string invoiceNo);
        Task<SaleItemReport> GetSaleItemHeaderForReport(string invoiceNo);
        Task<List<SaleItemReport>> GetSaleItemDetailsForReport(string invoiceNo);        
    }
}
