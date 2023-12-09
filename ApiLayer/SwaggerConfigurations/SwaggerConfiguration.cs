using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiLayer.SwaggerConfigurations
{
	public static class SwaggerConfiguration
	{
		private static readonly string _bearer = "Bearer";
		private static readonly string _version = "v1";

		public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
		{
			return services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc(_version, CreateInfo());
				options.AddSecurityDefinition(_bearer, CreateScheme());
				options.AddSecurityRequirement(CreateRequirement());
			});


		}

		private static OpenApiSecurityScheme CreateScheme()
		{
			return new OpenApiSecurityScheme()
			{
				Name = "JWT Bearer token",
				Type = SecuritySchemeType.Http,
				Scheme = _bearer,
				BearerFormat = "JWT",
				In = ParameterLocation.Header,
				Description = "JWT Bearer token Authorization",
			};
		}

		private static OpenApiSecurityRequirement CreateRequirement()
		{
			return new OpenApiSecurityRequirement()
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = _bearer
						},
						Scheme = JwtBearerDefaults.AuthenticationScheme,
						Name = JwtBearerDefaults.AuthenticationScheme
					},
					new List<string>()
				}
			};
		}

		private static OpenApiInfo CreateInfo()
		{
			return new OpenApiInfo()
			{
				Version = _version,
				Title = "AuthComponent",
	
			};
		}
	}
}
