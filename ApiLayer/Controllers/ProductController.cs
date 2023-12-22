using Application.Abstractions.Services;
using Application.Dtos.AuthDtos;
using Application.Dtos.EntitiesDtos;
using Domain.PaginationEntities;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class ProductController : ControllerBase
	{

		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpPost]
		[ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
		public async Task<IActionResult> GetAllProdutsAsync([FromQuery]Pagination pagination)
		{
			return Ok(await _productService.GetAllProduct(pagination));
		}
		[HttpPost]
		public async Task<IActionResult> CreateProductAsync([FromBody] ProductDto dto)
		{
			await _productService.CreateProduct(dto);
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProductAsync(Guid id)
		{
			await _productService.DeleteProduct(id);
			return Ok();
		}
	}
}
