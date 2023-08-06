using Core.Application.Interface.Procurment;
using Core.Domain.Procurement;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Procurment
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PurchaseOrderController : BaseApiController
    {
        //private readonly IPurchaseOrder _purchaseOrder;
        //public PurchaseOrderController(IPurchaseOrder purchaseOrder)
        //{
        //    _purchaseOrder = purchaseOrder;
        //}
        //[HttpPost("save-purchase-order-details")]
        //public async Task<IActionResult> Post([FromBody] List<PurchaseOrder> purchaseOrder)
        //{
        //    var result = await _purchaseOrder.AddPurchaseOrder(purchaseOrder);
        //    return Ok(result);
        //    //if (!result)
        //    //{
        //    //    return Ok(false);
        //    //}
        //    //else
        //    //{
        //    //    return Ok(true);
        //    //}

        //    //foreach (var item in purchaseOrder)
        //    //{
        //    //    if (item.Id == null || item.Id == 0)
        //    //    {
        //    //        var result = await _purchaseOrder.AddPurchaseOrder(purchaseOrder);
        //    //        if (!result)
        //    //        {
        //    //            return Ok(false);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        var result = await _purchaseOrder.AddPurchaseOrder(purchaseOrder);
        //    //        if (!result)
        //    //        {
        //    //            return Ok(false);
        //    //        }
        //    //    }
        //    //}
        //}
        //[HttpGet("get-brand-id/{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var brand = await _purchaseOrder.GetBrandById(id);
        //    if (brand is null)
        //        return NotFound();
        //    return Ok(brand);
        //}

        //[HttpGet("get-purchaseOrder-by-invoiceNo/{invoiceNo}")]
        //public async Task<IActionResult> Get(string invoiceNo)
        //{
        //    var brand = await _purchaseOrder.GetPurchaseOrder(invoiceNo);
        //    if (brand is null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(brand);
        //    }
        //}
    }
}
