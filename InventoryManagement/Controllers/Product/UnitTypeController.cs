using Core.Application.Interface.Product;
using Core.Domain.BasicInfo;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Product
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UnitTypeController : BaseApiController
    {
        private readonly IUnitType _unitType;
        public UnitTypeController(IUnitType unitType)
        {
            _unitType = unitType;
        }

        [HttpPost("save-unitType")]
        public async Task<IActionResult> Post([FromBody] UnitType unitType)
        {
            if (unitType.Id == null || unitType.Id == 0)
            {
                var result = await _unitType.AddUnitType(unitType);
                if (!result)
                {
                    return Ok(false);
                }
            }
            else
            {
                var result = await _unitType.AddUnitType(unitType);
                if (!result)
                {
                    return Ok(false);
                }
            }
            return Ok(true);
        }

        [HttpGet("get-unitType")]
        public async Task<IActionResult> Get()
        {
            var brand = await _unitType.GetUnitType();
            return Ok(brand);
        }

        [HttpDelete("delete-unitType/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitType.DeleteUnitType(id);
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
