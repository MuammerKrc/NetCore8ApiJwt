using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AuthEntities;
using Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DbContexts
{
	public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			
		}

		DbSet<RefreshToken> RefreshTokens { get; set; }
	}
}
