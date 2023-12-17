using Application.Abstractions.Services;
using Application.IUnitOfWorks;
using Domain.IdentityEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContexts;
using Persistence.Mapping;
using Persistence.Services;
using Persistence.UnitOfWorks;

namespace Persistence
{
	public static class PersistenceRegistration
	{
		public static void PersistenceRegistrationService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(i =>
			{
				i.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), opt =>
				{
					opt.MigrationsAssembly(typeof(PersistenceRegistration).Assembly.GetName().Name);
				});
			});

			services.AddIdentity<AppUser, AppRole>(opt =>
			{

				opt.User.RequireUniqueEmail = true;
				opt.Password.RequireDigit = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequiredLength = 5;
				opt.Password.RequiredUniqueChars = 3;

			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

			services.AddAutoMapper(typeof(Mapper));

			//UnitOfWorks
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			//Services
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IProductService, ProductService>();
		}
		public static IEndpointRouteBuilder BuildAllAndPoints(this IEndpointRouteBuilder endpointRouteBuilder)
		{
			//var type = typeof(IRegisterEndpoint);

			//var typesEndPoint = AppDomain.CurrentDomain.GetAssemblies()
			//	.SelectMany(s => s.GetTypes())
			//	.Where(p => type.IsAssignableFrom(p) && p.IsClass).ToList();


			//typesEndPoint.ForEach(i =>
			//{
			//	if (i.Namespace == nameof(UserService))
			//	{
			//		endpointRouteBuilder.MapGroup(i.Name).MapPost("v1/asd", handler: async (CreateUserDto dto, [FromServices]) => await dto.Name).Produces<string>().WithName("deneme").AllowAnonymous();

			//	}

			//	var convertedClassFromTyoe = Convert.ChangeType(nameof(i.Name).Cast<>(),i);

			//	endpointRouteBuilder.MapGet("v1/getServiceInfo",
			//			async ([FromServices] Activator.CreateInstance() getServiceInfoQueryHandler, CancellationToken cancellationToken) =>
			//			await getServiceInfoQueryHandler.CreateUser(, cancellationToken))
			//		.Produces<JWTokensDto>()
			//		.WithName("GetServiceInfo")
			//		.RequireAuthorization(AuthorizationConfiguration.UserPolicyName)
			//		.WithOpenApi();
			//});
			return endpointRouteBuilder
				.MapGroup("user");
		}
	}
}
