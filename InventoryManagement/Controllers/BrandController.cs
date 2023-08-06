using Core.Applicatio;
using Core.Domain.Brand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InventoryManagement.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrand _brand;
        public BrandController(IBrand brand)
        {
            _brand = brand;
        }

        [HttpPost("save-brand")]
        public async Task<IActionResult> Post( [FromBody] Brand brand)
        {
                if (brand.Id == null|| brand.Id == 0)
                {
                    var result = await _brand.AddBrand(brand);
                    if (!result)
                    {
                        return BadRequest("could not save data");
                    }
                }
                else
                {
                    var result = await _brand.AddBrand(brand);
                    if (!result)
                    {
                        return BadRequest("could not save data");
                    }
                }
            return Ok(true);
        }

        //[HttpPut("update-brand/{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] Brand newBrand)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid data");
        //    var brand = await _brand.GetBrandById(id);
        //    if (brand is null)
        //        return NotFound();
        //    newBrand.Id = id;
        //    var result = await _brand.UpdateBrand(newBrand);
        //    if (!result)
        //        return BadRequest("could not save data");
        //    return Ok();
        //}

        [HttpDelete("delete-brand/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _brand.DeleteBrand(id);
            if (!result)
            {
                return BadRequest(false);
            }
            return Ok(true);
        }

        [HttpGet("get-brand-by-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await _brand.GetBrandById(id);
            if (brand is null)
                return NotFound();
            return Ok(brand);
        }

        [HttpGet("get-brand")]
        public async Task<IActionResult> Get()
        {
            var brand = await _brand.GetBrand();
            return Ok(brand);
        }
    }
}
