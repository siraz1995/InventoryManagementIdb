using Core.Application.Interface.Authentication;
using Core.Domain.Authentication;
using Core.Domain.Brand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.Authentication
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("save-registration-info")]
        public async Task<IActionResult>SaveRegistrationForm([FromBody]Registration model)
        {
            if (model.Id == null || model.Id == 0)
            {
                var result =await _authentication.SaveRegistrationForm(model);
                if (!result)
                {
                    return Ok(false);
                }
                else
                {
                    return Ok(true);
                }
            }
            else
            {
                var result = await _authentication.SaveRegistrationForm(model);
                if (!result)
                {
                    return Ok(false);
                }
                else
                {
                    return Ok(true);
                }
            }
            return Ok(true);
        }
        [HttpGet("get-user-by-userName/{userName}")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var result = await _authentication.GetUserByUserName(userName);
            return Ok(result);
        }

        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserByid(int id)
        {
            var result = await _authentication.GetUserById(id);
            return Ok(result);
        }

        [HttpPost("save-role")]
        public async Task<IActionResult> SaveRole([FromBody] Role model)
        {
            if (model.Id == null || model.Id == 0)
            {
                var result = await _authentication.SaveRole(model);
                if (!result)
                {
                    return Ok(false);
                }
                else
                {
                    return Ok(true);
                }
            }
            else
            {
                var result = await _authentication.SaveRole(model);
                if (!result)
                {
                    return Ok(false);
                }
            }
            return Ok(true);
        }
        [HttpGet("get-role")]
        public async Task<IActionResult> GetRole()
        {
            var result = await _authentication.GetRole();
            return Ok(result);
        }

        [HttpDelete("delete-role/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var brand = await _brand.GetBrandById(id);
            //if (brand is null)
            //    return NotFound();
            var result = await _authentication.DeleteRole(id);
            if (!result)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [HttpGet("get-register-user")]
        public async Task<IActionResult> GetRegisterUser()
        {
            var result = await _authentication.GetRegisterUser();
            return Ok(result);
        }


    }
}
