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
    public class SalesReturnController : BaseApiController
    {
        private readonly ISalesReturn _salesReturn;
        public SalesReturnController(ISalesReturn salesReturn)
        {
            _salesReturn = salesReturn;
        }

        [HttpPost("Save")]
        public async Task<ResponseType> Save([FromBody] SalesInput invoiceEntity)
        {
            return await this._salesReturn.Save(invoiceEntity);
        }
        [HttpGet("GetAllHeader")]
        public async Task<List<SalesInfoHeader>> GetAllHeader()
        {
            return await this._salesReturn.GetAllInvoiceHeader();
        }
        
        [HttpGet("GetAllHeaderbyCode/{invoiceNo}")]
        public async Task<SalesInfoHeader> GetAllHeaderbyCode(string invoiceNo)
        {
            return await this._salesReturn.GetAllInvoiceHeaderbyCode(invoiceNo);

        }

        [HttpGet("GetAllDetailbyCode/{invoiceNo}")]
        public async Task<List<SalesInfoDetails>> GetAllDetailbyCode(string invoiceNo)
        {
            return await this._salesReturn.GetAllInvoiceDetailbyCode(invoiceNo);

        }
        [HttpDelete("Remove/{invoiceNo}")]
        public async Task<ResponseType> Remove(string InvoiceNo)
        {
            return await this._salesReturn.Remove(InvoiceNo);

        }
        [HttpGet("get-sales-item-return-header-for-report/{invoiceNo}")]
        public async Task<SaleItemReport> GetSaleItemReturnHeaderForReport(string invoiceNo)
        {
            return await this._salesReturn.GetSaleItemReturnHeaderForReport(invoiceNo);
        }

        [HttpGet("get-sales-item-return-details-for-report/{invoiceNo}")]
        public async Task<List<SaleItemReport>> GetSaleItemReturnDetailsForReport(string invoiceNo)
        {
            return await this._salesReturn.GetSaleItemReturnDetailsForReport(invoiceNo);
        }
    }
}
