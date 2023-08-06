using Core.Application.Interface.Procurment;
using Core.Application.Interface.Product;
using Core.Domain.BasicInfo;
using Core.Domain.Procurement;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Procurment
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class SupplierController : BaseApiController
    {
        private readonly ISupplier _supplier;
        public SupplierController( ISupplier supplier) 
        {
            _supplier = supplier;
        }

        [HttpPost("save-supplier")]
        public async Task<IActionResult> Post([FromBody] Supplier supplier)
        {

                var result = await _supplier.AddSupplier(supplier);
                return Ok(result);
                //if (supplier.Id == null || supplier.Id == 0)
                //{
                //    var result = await _supplier.AddSupplier(supplier);
                //    if (!result)
                //    {
                //        return Ok(false);
                //    }
                //}
                //else
                //{
                //    var result = await _supplier.AddSupplier(supplier);
                //    if (!result)
                //    {
                //        return Ok(false);
                //    }
                //}
                //return Ok(true);
            }
        [HttpGet("get-supplier")]
        public async Task<IActionResult> Get()
        {
            var brand = await _supplier.GeSupplier();
            return Ok(brand);
        }

        [HttpDelete("delete-supplier/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _supplier.DeleteSupplier(id);
            if (!result)
            {
                return BadRequest(false);
            }
            else
            {
                return Ok(true);
            }
        }
    }
}
