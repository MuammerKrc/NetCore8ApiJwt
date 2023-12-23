using Application.Abstractions.Hubs;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos.EntitiesDtos;
using Application.IUnitOfWorks;
using Domain.Entities;
using Domain.PaginationEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Persistence.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
	public class ProductService : BaseService, IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private IProductRepositories _productRepositories { get; }
		private IProductHubService _productHubService;

		public ProductService(IServiceProvider provider, IUnitOfWork unitOfWork, IProductHubService productHubService) : base(provider)
		{
			_unitOfWork = unitOfWork;
			_productRepositories = _unitOfWork.ProductRepositories;
			_productHubService = productHubService;
		}


		public async Task CreateProduct(ProductDto dto)
		{
			_productRepositories.Add(_mapper.Map<Product>(dto));
			await _unitOfWork.SaveAsync();
			await _productHubService.ProductAddedMessageAsync("ürün eklendi");
		}

		public async Task<List<ProductDto>> GetAllProduct(Pagination pagination)
		{
			var result = await _productRepositories.GetContext().Skip((pagination.PageIndex - 1) * pagination.TotalCount).Take(pagination.TotalCount).ToListAsync();
			return _mapper.Map<List<ProductDto>>(result);
		}

		public async Task DeleteProduct(Guid id)
		{
			await _productRepositories.Delete(id);
			await _unitOfWork.SaveAsync();
		}

	}
}
