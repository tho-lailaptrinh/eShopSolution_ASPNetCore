
using eShopSolution.Application.System.Users;
using eShopSolution.ViewModels.System.Logins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;
        public UsersController(IUserService userService) 
        {
// điều này cho phép UserController sử dụng các phương thức và thuộc tính của UserService thông qua _userservice
            _userService = userService; 
// điều này giúp tăng tính linh hoạt vằ khả năng kiểm thử - dễ bảo trì
        }
        [HttpPost]
        [AllowAnonymous] // Chưa đăng nhập cũng gọi được hàm này (Authencate) 
        public async Task<IActionResult> Authencate([FromForm]LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Authencate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("UserName or Password is incorrect");
            }
            return Ok(new { token = resultToken});
        }

        [HttpPost("reister")]
        [AllowAnonymous] // Chưa đăng nhập cũng gọi được hàm này (Authencate) 
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest("Register is unsuccessful");
            }
            return Ok();  
        }
    }
}
