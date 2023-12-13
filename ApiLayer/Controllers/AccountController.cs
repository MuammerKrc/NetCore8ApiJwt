using Application.Abstractions.Services;
using Application.Dtos.AuthDtos;
using Application.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class AccountController : ControllerBase
	{
		private readonly IUserService _userService;

		public AccountController(IUserService userService)
		{
			_userService = userService;
		}
		[HttpPost]
		[ProducesResponseType(typeof(JWTokensDto), StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
		{
			return new ObjectResult(await _userService.CreateUser(userDto));
		}
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
		{
			return new ObjectResult(await _userService.UserLogin(userLoginDto));
		}
		[HttpPost]
		public async Task<IActionResult> LoginWithRefreshToken([FromBody] LoginWithRefreshTokenDto refreshTokenDto)
		{
			return Ok(await _userService.LoginWithRefreshToken(refreshTokenDto));
		}
	}
}
