using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Domain.IdentityEntities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class InfrastructureRegistration
	{
		public static void InfrastructureRegistrationService(this IServiceCollection service, IConfiguration configuration)
		{
			service.AddScoped<ITokenService, TokenService>();
		}
	}
}
