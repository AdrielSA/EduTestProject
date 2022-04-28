using EduTest.Domain.Entities;
using EduTest.Infrastructure.Context;
using EduTest.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EduTest.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _entities;

        public Repository(EduTestDbContext context)
        {
            _entities = context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter != null ?
                await _entities.Where(filter).ToListAsync() :
                await _entities.ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await GetAsync(id);
            _entities.Remove(entity);
        }
    }
}
