using Core.Application.Interface.Sales;
using Core.Domain.Procurement.Purchase;
using Core.Domain.Procurement;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Domain.Sales;

namespace InventoryManagement.Controllers.Sales
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class SalesController : BaseApiController
    {
        private readonly ISales _sales;
        public  SalesController(ISales sales)
        {
            _sales = sales;
        }

        [HttpPost("savesalesitem")]
        public async Task<ResponseType> Save([FromBody] SalesInput invoiceEntity)
        {
            return await this._sales.Save(invoiceEntity);

        }

        [HttpGet("get-sales-item-header-list")]
        public async Task<List<SalesInfoHeader>> GetSalesHeaderList()
        {
            return await this._sales.GetSalesHeaderList();
        }

        [HttpGet("get-sales-item-header-by-invoice/{invoiceNo}")]
        public async Task<SalesInfoHeader> GetPurchaseOrderHeaderByInvoice(string invoiceNo)
        {
            return await this._sales.GeSalesHeaderByInvoice(invoiceNo);
        }

        [HttpGet("get-sales-item-details-by-invoice/{invoiceNo}")]
        public async Task<List<SalesInfoDetails>> GetPurchaseOrderDetailsByInvoice(string invoiceNo)
        {
            return await this._sales.GetSalesDetailsByInvoice(invoiceNo);
        }

        [HttpDelete("remove-sales-item/{invoiceNo}")]
        public async Task<ResponseType> Remove(string invoiceNo)
        {
            return await this._sales.Remove(invoiceNo);
        }

        [HttpGet("get-sales-item-header-for-report/{invoiceNo}")]
        public async Task<SaleItemReport> GetSaleItemHeaderForReport(string invoiceNo)
        {
            return await this._sales.GetSaleItemHeaderForReport(invoiceNo);
        }

        [HttpGet("get-sales-item-details-for-report/{invoiceNo}")]
        public async Task<List<SaleItemReport>> GetSaleItemDetailsForReport(string invoiceNo)
        {
            return await this._sales.GetSaleItemDetailsForReport(invoiceNo);
        }

    }
}
