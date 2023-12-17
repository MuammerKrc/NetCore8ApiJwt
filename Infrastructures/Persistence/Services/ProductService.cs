using Application.Abstractions.Repositories;
using Application.Dtos.EntitiesDtos;
using Application.IUnitOfWorks;
using Domain.Entities;
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
	public class ProductService : BaseService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IProductRepositories _productRepositories;

		public ProductService(IServiceProvider provider, IUnitOfWork unitOfWork) : base(provider)
		{
			_unitOfWork = unitOfWork;
			_productRepositories = _unitOfWork.ProductRepositories;
		}


		public async Task CreateProduct(ProductDto dto)
		{
			_productRepositories.Add(_mapper.Map<Product>(dto));
			await _unitOfWork.SaveAsync();
		}

	}
}
