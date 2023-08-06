using Core.Application.Interface.Product;
using InventoryManagement.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Product
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("save-product")]
        public async Task<IActionResult> SaveProduct([FromBody] Core.Domain.BasicInfo.Product product)
        {
            if(product.Id== 0 || product.Id==null)
            {
                var result=await _repository.AddProduct(product);
                if (!result)
                {
                    return Ok(false);
                }
            }
            else
            {
                var result =await _repository.AddProduct(product);
                if (!result)
                {
                    return Ok(false);
                }
            }
            return Ok(true);
        }

        [HttpGet("get-product")]
        public async Task<IActionResult> GetProductList()
        {
            var result = await _repository.GetProductList();
            return Ok(result);
        }
        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var result = await _repository.DeleteProductById(id);
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
