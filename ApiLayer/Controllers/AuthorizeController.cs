using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	[Authorize("deneme")]
	public class AuthorizeController : ControllerBase
	{
		// GET: AuthorizeController

		[HttpPost]
		public ActionResult Index()
		{
			return Ok();
		}


	}
}
