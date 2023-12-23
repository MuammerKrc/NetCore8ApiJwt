using Application.Abstractions.Hubs;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.HubServices
{
	public class ProductHubService : IProductHubService
	{
		readonly IHubContext<ProductHub> _hubContext;

		public ProductHubService(IHubContext<ProductHub> hubContext)
		{
			_hubContext = hubContext;
		}

		public async Task ProductAddedMessageAsync(string message)
		{
			await _hubContext.Clients.All.SendAsync("productAdded", message);
		}
	}
}
