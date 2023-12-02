using Application.RoleNameProviders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]

	public class AuthorizeController : ControllerBase
	{

		[HttpPost]
		[Authorize(Roles = "AdminRole")]
		public ActionResult AdminRoleCheck()
		{
			Console.WriteLine(HttpContext.User.Identity.Name);
			return Ok();
		}
	}
}
