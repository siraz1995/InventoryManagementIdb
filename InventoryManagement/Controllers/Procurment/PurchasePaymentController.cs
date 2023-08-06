using Core.Application.Interface.Procurment;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Procurment
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PurchasePaymentController : BaseApiController
    {
        private readonly IPurchasePayment _purchasePayment;
        public PurchasePaymentController(IPurchasePayment purchasePayment)
        {
            _purchasePayment = purchasePayment;
        }
        [HttpGet("get-unpaid-purchase-order")]
        public async Task<IActionResult> getUnPaidPurchaseOrder()
        {
            var result = await _purchasePayment.GetAll();
            return Ok(result);
        }
        [HttpGet("make-purchase-payment/{invoiceNo}")]
        public async Task<IActionResult> UpdatePurchaseHeader(string invoiceNo)
        {
            var result =await _purchasePayment.UpdatePurchaseHeader(invoiceNo);
            if (!result)
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }
        }
    }
}
