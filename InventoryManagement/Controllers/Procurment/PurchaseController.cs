using Core.Domain.Procurement.Purchase;
using Core.Domain.Procurement;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Interface.Procurment;

namespace InventoryManagement.Controllers.Procurment
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PurchaseController : BaseApiController
    {

        private readonly Iinvoice _invoice;
        public PurchaseController(Iinvoice container)
        {
            _invoice = container;
        }

        [HttpPost("save-purchase-order-detail")]
        public async Task<ResponseType> Save([FromBody] InvoiceInput invoiceEntity)
        {
            return await this._invoice.Save(invoiceEntity);

        }
        [HttpGet("get-purchase-order-header-list")]
        public async Task<List<InvoiceHeader>> GetPurchaseOrderHeaderList()
        {
            return await this._invoice.GetPurchaseOrderHeaderList();
        }

        [HttpGet("get-purchase-order-header-by-invoice/{invoiceNo}")]
        public async Task<InvoiceHeader> GetPurchaseOrderHeaderByInvoice(string invoiceNo)
        {
            return await this._invoice.GetPurchaseOrderHeaderByInvoice(invoiceNo);
        }

        [HttpGet("get-purchase-order-details-by-invoice/{invoiceNo}")]
        public async Task<List<InvoiceDetail>> GetPurchaseOrderDetailsByInvoice(string invoiceNo)
        {
            return await this._invoice.GetPurchaseOrderDetailsByInvoice(invoiceNo);
        }

        [HttpDelete("remove-purchase-order/{invoiceNo}")]
        public async Task<ResponseType> Remove(string invoiceNo)
        {
            return await this._invoice.Remove(invoiceNo);
        }

        [HttpGet("get-purchase-order-header-for-report/{invoiceNo}")]
        public async Task<PurchaseOrderReport> GetPurchaseOrderHeaderForReport(string invoiceNo)
        {
            return await this._invoice.GetPurchaseOrderHeaderForReport(invoiceNo);
        }
        [HttpGet("get-purchase-order-details-for-report/{invoiceNo}")]
        public async Task<List<PurchaseOrderReport>> GetPurchaseOrderDetailsForReport(string invoiceNo)
        {
            return await this._invoice.GetPurchaseOrderDetailsForReport(invoiceNo);
        }
    }
}
