using Core.Application.Interface.Item_Stock;
using Infrastructure.Repository.ItemStock;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Item_In_Stock
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _repository;
        public StockController(IStockRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("get-stock-item")]
        public async Task<IActionResult> GetStock()
        {
            var result =await _repository.GetStockItem();
            return Ok(result);
        }
    }
}
