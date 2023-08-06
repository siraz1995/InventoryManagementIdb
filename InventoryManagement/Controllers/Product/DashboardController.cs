using Core.Application.Interface.Authentication;
using Core.Application.Interface.Product;
using Core.Domain.BasicInfo;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Product
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class DashboardController : BaseApiController
    {
        private readonly IDashboard _dashboard;
        public DashboardController(IDashboard dashboard)
        {
            _dashboard = dashboard;
        }

        [HttpGet("get-complete-purchase-order")]
        public async Task<IActionResult> GetCompletePurchaseOrder()
        {
            var completePurchaseOrder = await _dashboard.GetCompletePurchaseOrder();
            return Ok(completePurchaseOrder);
        }

        [HttpGet("get-pending-purchase-order")]
        public async Task<IActionResult> GetPendingPurchaseOrder()
        {
            var pendingPurchaseOrder = await _dashboard.GetPendingPurchaseOrder();
            return Ok(pendingPurchaseOrder);
        }
        [HttpGet("get-active-user")]
        public async Task<IActionResult> GetActiveUser()
        {
            var result = await _dashboard.GetActiveUser();
            return Ok(result);
        }
        [HttpGet("get-inactive-user")]
        public async Task<IActionResult> GetInActiveUser()
        {
            var result = await _dashboard.GetInActiveUser();
            return Ok(result);
        }
    }
}
