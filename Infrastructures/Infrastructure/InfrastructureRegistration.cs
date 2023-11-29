using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
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
