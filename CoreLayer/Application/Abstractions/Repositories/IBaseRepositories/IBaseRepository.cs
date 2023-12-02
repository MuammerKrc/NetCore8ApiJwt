using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.BaseEntities;

namespace Application.Abstractions.Repositories.IBaseRepositories
{
    public interface IBaseRepository<TModel, TKey> where TModel : BaseModel<TKey>
    {
        DbSet<TModel> _entities { get; }
        void Add(TModel model);
        int GetCount();
        Task AddAll(IEnumerable<TModel> models);
        void Update(TModel model);
        Task Delete(TKey id);
        Task SoftDelete(TKey id);
        Task<IEnumerable<TModel>> GetAllAsync(bool tracking = false);
        Task<TModel> GetByIdAsync(TKey id, bool tracking = false);
        IQueryable<TModel> GetWhereAsync(Expression<Func<TModel, bool>> method);
        Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> method, bool tracking = false);
        DbSet<TModel> GetContext();
        Task<int> SaveAsync();
    }
}
