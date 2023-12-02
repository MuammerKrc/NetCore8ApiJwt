using Application.Abstractions.Services;
using Application.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class AccountController : Controller
	{
		private readonly IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
		{
			return Ok(await _userService.CreateUser(userDto));
		}
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
		{
			return Ok(await _userService.UserLogin(userLoginDto));
		}
		[HttpPost]
		public async Task<IActionResult> LoginWithRefreshToken([FromBody] LoginWithRefreshTokenDto refreshTokenDto)
		{
			return Ok(await _userService.LoginWithRefreshToken(refreshTokenDto));
		}
	}
}
