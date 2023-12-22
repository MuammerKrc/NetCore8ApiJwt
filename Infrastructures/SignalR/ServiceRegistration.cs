using Application.Abstractions.Hubs;
using Microsoft.Extensions.DependencyInjection;
using SignalR.HubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR
{
	public static class ServiceRegistration
	{
		public static void SignalRServiceRegistration(this IServiceCollection services)
		{

			services.AddTransient<IProductHubService, ProductHubService>();
			services.AddSignalR();
		}
	}
}
