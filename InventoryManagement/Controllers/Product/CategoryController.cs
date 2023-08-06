using Core.Applicatio;
using Core.Application.Interface.Product;
using Core.Domain.BasicInfo;
using Core.Domain.Brand;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Product
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CategoryController : BaseApiController
    {
        private readonly ICategory _catrgory;
        public CategoryController(ICategory catrgory)
        {
            _catrgory = catrgory;
        }

        [HttpPost("save-category")]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if (category.Id == null || category.Id == 0)
            {
                var result = await _catrgory.AddCategory(category);
                if (!result)
                {
                    return Ok(false);
                }
            }
            else
            {
                var result = await _catrgory.AddCategory(category);
                if (!result)
                {
                    return Ok(false);
                }
            }
            return Ok(true);
        }

        [HttpGet("get-category")]
        public async Task<IActionResult> Get()
        {
            var brand = await _catrgory.GetCategory();
            return Ok(brand);
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _catrgory.DeleteCategory(id);
            if (!result)
            {
                return BadRequest(false);
            }
            return Ok(true);
        }
    }
}
