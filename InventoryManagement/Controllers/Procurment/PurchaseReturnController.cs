using Core.Application.Interface.Procurment;
using Core.Domain.Procurement.Purchase;
using Core.Domain.Procurement;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Procurment
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PurchaseReturnController : BaseApiController
    {
        private readonly IPurchaseReturn _purchaseReturn;
        public PurchaseReturnController(IPurchaseReturn purchaseReturn)
        {
            _purchaseReturn = purchaseReturn;
        }

        [HttpPost("save-purchase-order-return-detail")]
        public async Task<ResponseType> Save([FromBody] InvoiceInput invoiceEntity)
        {
            return await this._purchaseReturn.Save(invoiceEntity);

        }
        [HttpGet("get-purchase-order-return-header-list")]
        public async Task<List<InvoiceHeader>> GetPurchaseOrderHeaderList()
        {
            return await this._purchaseReturn.GetPurchaseOrderReturnHeaderList();
        }
        [HttpGet("get-purchase-order-return-header-by-invoice/{invoiceNo}")]
        public async Task<InvoiceHeader> GetPurchaseOrderHeaderByInvoice(string invoiceNo)
        {
            return await this._purchaseReturn.GetPurchaseOrderReturnHeaderByInvoice(invoiceNo);
        }

        [HttpGet("get-purchase-order-return-details-by-invoice/{invoiceNo}")]
        public async Task<List<InvoiceDetail>> GetPurchaseOrderDetailsByInvoice(string invoiceNo)
        {
            return await this._purchaseReturn.GetPurchaseOrderReturnDetailsByInvoice(invoiceNo);
        }

        [HttpDelete("remove-purchase-order-return/{invoiceNo}")]
        public async Task<ResponseType> Remove(string invoiceNo)
        {
            return await this._purchaseReturn.Remove(invoiceNo);
        }

        [HttpGet("get-purchase-order-return-header-for-report/{invoiceNo}")]
        public async Task<PurchaseOrderReport> GetPurchaseOrderReturnHeaderForReport(string invoiceNo)
        {
            return await this._purchaseReturn.GetPurchaseOrderReturnHeaderForReport(invoiceNo);
        }
        [HttpGet("get-purchase-order-return-details-for-report/{invoiceNo}")]
        public async Task<List<PurchaseOrderReport>> GetPurchaseOrderReturnDetailsForReport(string invoiceNo)
        {
            return await this._purchaseReturn.GetPurchaseOrderReturnDetailsForReport(invoiceNo);
        }
    }
}
