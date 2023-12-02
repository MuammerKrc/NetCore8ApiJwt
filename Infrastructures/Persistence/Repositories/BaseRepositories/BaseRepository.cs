using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Repositories.IBaseRepositories;
using Application.Exceptions;
using Domain.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContexts;

namespace Infrastructure.Repositories.BaseRepositories
{
	public class BaseRepository<TModel, TKey> : IBaseRepository<TModel, TKey> where TModel : BaseModel<TKey>
	{
		public AppDbContext _context { get; }

		public BaseRepository(AppDbContext context)
		{
			_context = context;
		}

		public DbSet<TModel> _entities => _context.Set<TModel>();

		public void Add(TModel model)
		{
			_context.Set<TModel>().Add(model);
		}

		public int GetCount()
		{
			return _entities.Count();
		}

		public async Task AddAll(IEnumerable<TModel> models)
		{
			await _entities.AddRangeAsync(models);
			//models.ToList().ForEach(i => _context.Entry<TModel>(i).State = EntityState.Added);
		}

		public void Update(TModel model)
		{
			_entities.Update(model);

			_context.Entry<TModel>(model).State = EntityState.Modified;
		}

		public async Task Delete(TKey id)
		{
			var result = await GetByIdAsync(id, true);
			//_entities.Remove(result);

			_context.Entry<TModel>(result).State = EntityState.Deleted;
		}

		public async Task SoftDelete(TKey id)
		{
			var result = await GetByIdAsync(id, true);
			result.SoftDeleted = true;
		}

		public async Task<IEnumerable<TModel>> GetAllAsync(bool tracking = false)
		{
			if (tracking)
				return await _entities.AsNoTracking().ToListAsync();
			return await _entities.ToListAsync();
		}

		public async Task<TModel> GetByIdAsync(TKey id, bool tracking = false)
		{
			var querableRequest = _entities.Where(i => i.Id.Equals(id));
			if (!tracking)
				querableRequest = querableRequest.AsNoTracking();

			var response = await querableRequest.FirstOrDefaultAsync();
			if (response == null)
				throw new UserFriendlyExceptions("");
			return response;

		}

		public IQueryable<TModel> GetWhereAsync(Expression<Func<TModel, bool>> method)
		{
			return _entities.Where(method).AsQueryable();

		}

		public async Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> method, bool tracking = false)
		{
			var querableRequest = _entities.Where(method);
			if (!tracking)
				querableRequest = querableRequest.AsNoTracking();
			return await querableRequest.FirstOrDefaultAsync();
		}

		public DbSet<TModel> GetContext()
		{
			return _entities;
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
