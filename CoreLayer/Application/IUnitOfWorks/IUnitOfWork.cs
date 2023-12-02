using Application.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IUnitOfWorks
{
	public interface IUnitOfWork
	{
		Task<bool> SaveAsync();

		public IRefreshTokenRepositories RefreshTokenRepositories { get; }
	}
}
