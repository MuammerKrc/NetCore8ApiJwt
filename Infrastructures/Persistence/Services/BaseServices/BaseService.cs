using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services.BaseServices;
using Application.IUnitOfWorks;
using AutoMapper;
using Domain.AuthEntities;
using Domain.IdentityEntities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

		public string? AppUserId => _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(i => i.Type == JwtRegisteredClaimNames.NameId).Value;

		//public IQueryable<AppUser> GetCurrentUserReadyQuery(Expression<Func<bool, AppUser>> expression)
		//{
		//	return expression;
		//}
	}
}
