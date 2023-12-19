using Application.Dtos.EntitiesDtos;
using Domain.PaginationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
	public interface IProductService
	{
		Task<List<ProductDto>> GetAllProduct(Pagination pagination);
		Task CreateProduct(ProductDto dto);

	}
}
