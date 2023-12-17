using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ApiLayer.Extensions
{
	public static class ConfigureExceptionHandlerExtension
	{
		public static void ConfigureExceptionHandler(this WebApplication app)
		{
			app.UseExceptionHandler(builder =>
			{
				builder.Run(async context =>
				{
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						if (contextFeature.Error != null && contextFeature.Error is UserFriendlyExceptions)
						{
							context.Response.StatusCode = 502;
							context.Response.ContentType = MediaTypeNames.Application.Json;
							await context.Response.WriteAsync(JsonSerializer.Serialize(
								new
							{
								StatusCode = 502,
								Message = contextFeature.Error.Message,
								Title = "Hata Alındı!"
							}));
						}
						else
						{
							context.Response.StatusCode = 500;
							context.Response.ContentType = MediaTypeNames.Application.Json;
							await context.Response.WriteAsync(JsonSerializer.Serialize(new
							{
								StatusCode = context.Response.StatusCode,
								Message = contextFeature.Error.Message,
								Title = "Hata Alındı!"
							}));
						}
					}
					else
					{
						context.Response.StatusCode = 500;
						context.Response.ContentType = MediaTypeNames.Application.Json;
					}
				});
			});
		}
	}
}
