using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Application.IUnitOfWorks;
using Infrastructure.Repositories;
using Persistence.DbContexts;
using Persistence.Repositories;

namespace Persistence.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		public readonly AppDbContext _context;
		public UnitOfWork(AppDbContext context)
		{
			_context = context;
		}

		private RefreshTokenRepositories _refreshTokenRepositories;
		private ProductRepositories _productRepositories;
		public IRefreshTokenRepositories RefreshTokenRepositories => _refreshTokenRepositories ??= new RefreshTokenRepositories(context: _context);
		public IProductRepositories ProductRepositories => _productRepositories ??= new ProductRepositories(context: _context);

		public async Task<bool> SaveAsync()
		{
			var result = await _context.SaveChangesAsync();
			return result != 0;
		}

		public bool Save()
		{
			return _context.SaveChanges() != 0;
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
