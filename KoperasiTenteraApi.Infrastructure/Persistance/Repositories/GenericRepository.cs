using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using KoperasiTenteraApi.Domain.Common;
using KoperasiTenteraApi.Domain.Contracts;

namespace KoperasiTenteraApi.Infrastructure.Persistance.Repositories;

public abstract class GenericRepository<TEntity, TId>(KoperasiTenteraContext context) : IGenericRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : struct
{
    protected readonly KoperasiTenteraContext CalculatorContext = context;

    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public async virtual Task<TEntity> Add(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async virtual Task<IEnumerable<TEntity>> GetAll()
    {
        return await DbSet
            .AsNoTracking()
            .OrderBy(e => e.Id)
            .ToListAsync();
    }

    public async virtual Task<IEnumerable<TEntity>> GetAll(
        Expression<Func<TEntity, bool>>? expression = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool isDescending = false,
        int page = 1,
        int pageSize = 10)
    {
        var query = DbSet.AsQueryable();

        if (expression != null)
        {
            query = query.Where(expression);
        }

        if (orderBy != null)
        {
            query = isDescending
                ? query.OrderByDescending(orderBy)
                : query.OrderBy(orderBy);
        }
        else
        {
            query = isDescending
                ? query.OrderByDescending(e => e.Id)
                : query.OrderBy(e => e.Id);
        }

        query = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return await query.ToListAsync();
    }

    public async virtual Task<TEntity> GetById(TId id)
    {
        return await DbSet
            .AsNoTracking()
            .Where(e => e.Id.Equals(id))
            .FirstOrDefaultAsync();
    }

    // Better to add unit of work that will save all changes of tracked entites
    public virtual TEntity Update(TEntity entity)
    {
        DbSet.Update(entity);

        return entity;
    }
}
