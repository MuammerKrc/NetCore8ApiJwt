using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class ApplicationRegistration
	{
		public static void ApplicationRegistrationService(this IServiceCollection service,
			IConfiguration configuration)
		{
			service.Configure<TokenConfigurationModels>(configuration.GetSection("Token"));
		}
	}
}
