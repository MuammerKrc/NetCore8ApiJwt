using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services.BaseServices;
using Application.IUnitOfWorks;
using AutoMapper;
using Domain.AuthEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Services.BaseServices
{
	public class BaseService : IBaseService
	{
		public readonly IHttpContextAccessor _httpContextAccessor;
		public readonly IMapper _mapper;
		public readonly IUnitOfWork _unitOfWork;

		public BaseService(IServiceProvider provider)
		{
			_httpContextAccessor = provider.GetService<IHttpContextAccessor>();
			_mapper = provider.GetService<IMapper>();
			_unitOfWork = provider.GetService<IUnitOfWork>();
		}

		public string? AppUserId => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "asd").Value;
	}
}
