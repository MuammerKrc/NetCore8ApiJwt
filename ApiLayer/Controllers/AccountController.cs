using Application.Abstractions.Services;
using Application.Dtos.UserDtos;
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
	}
}
