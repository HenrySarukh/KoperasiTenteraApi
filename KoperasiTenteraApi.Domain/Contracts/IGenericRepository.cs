using KoperasiTenteraApi.Domain.Common;
using System.Linq.Expressions;

namespace KoperasiTenteraApi.Domain.Contracts;

public interface IGenericRepository<TEntity, TId>
    where TEntity : IEntity<TId>
    where TId : struct
{
    Task<TEntity> GetById(TId id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAll(
       Expression<Func<TEntity, bool>>? expression = null,
       Expression<Func<TEntity, object>>? orderBy = null,
       bool isDescending = false,
       int page = 1,
       int pageSize = 10);
    Task<TEntity> Add(TEntity entity);
    TEntity Update(TEntity entity);
}