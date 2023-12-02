using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Application.Abstractions.Repositories.IBaseRepositories;
using Domain.AuthEntities;
using Infrastructure.Repositories.BaseRepositories;
using Persistence.DbContexts;

namespace Infrastructure.Repositories
{
	public class RefreshTokenRepositories : BaseRepository<RefreshToken, Guid>, IRefreshTokenRepositories
	{
		public RefreshTokenRepositories(AppDbContext context) : base(context)
		{
		}
	}
}
