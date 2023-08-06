using Core.Application.Interface.Product;
using Core.Domain.BasicInfo;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Product
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class StoreController : BaseApiController
    {
        private readonly IStore _store;
        public StoreController(IStore store)
        {
            _store = store;
        }
        [HttpPost("save-store")]
        public async Task<IActionResult> Post([FromBody] Store store)
        {
            if (store.Id == null || store.Id == 0)
            {
                var result = await _store.AddStore(store);
                if (!result)
                {
                    return Ok(false);
                }
            }
            else
            {
                var result = await _store.AddStore(store);
                if (!result)
                {
                    return Ok(false);
                }
            }
            return Ok(true);
        }
        [HttpGet("get-store")]
        public async Task<IActionResult> Get()
        {
            var brand = await _store.GetStore();
            return Ok(brand);
        }

        [HttpDelete("delete-store/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _store.DeleteStore(id);
            if (!result)
            {
                return BadRequest(false);
            }
            else
            {
                return Ok(true);
            }
        }
        //[HttpGet("get-store-by-code/{code}")]
        //public async Task<IActionResult>GetStoreByCode(string code)
        //{
        //    var result = await _store.GetStoreByCode(string code);
        //    return result;
        //}
    }
}
