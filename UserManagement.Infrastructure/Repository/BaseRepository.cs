using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserManagement.Domain.RepositoryInterfaces;
using UserManagement.Infrastructure.Context;

namespace UserManagement.Infrastructure.Repository
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly UserManagementContext _db;
        internal DbSet<T> dbSet;
        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();

            return entity;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
            return entity;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
