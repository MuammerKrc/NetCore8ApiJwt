using Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.RoleNameProviders;

namespace Infrastructure
{
	public static class AddStaticRoleServiceCollectionExtensions
	{
		public static void AddStaticRolesConfigurationExtensions(this IServiceCollection collection)
		{

			var serviceProvider = collection.BuildServiceProvider();
			using (var scope = serviceProvider.CreateScope())
			{
				using (var roleManager = scope.ServiceProvider.GetService<RoleManager<AppRole>>())
				{
					var rolesFields = typeof(RoleNameProvider).GetFields();

					foreach (var rolesProperty in rolesFields)
					{
						var roleName = typeof(RoleNameProvider).GetField(rolesProperty.Name)?
							.GetValue(BindingFlags.GetField) as string;

						bool existRole = roleManager.RoleExistsAsync(roleName).Result;

						if (!existRole)
						{
							var IdentityResult = roleManager.CreateAsync(new AppRole()
							{
								Name = roleName,
								

								ConcurrencyStamp = Guid.NewGuid().ToString()
							}).Result;
						}
					}
				}
			}

		}
	}
}
