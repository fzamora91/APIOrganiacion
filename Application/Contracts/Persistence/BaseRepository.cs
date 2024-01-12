using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace Application.Contracts.Persistence
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected readonly TenantUsuarioDbContext _userContext;

        public BaseRepository(TenantUsuarioDbContext userContext)
        {
            _userContext = userContext;
        }


        public async Task<T> AddAsync(T entity)
        {
           await _userContext.Set<T>().AddAsync(entity);
           await _userContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _userContext.Set<T>().Remove(entity);
            await _userContext.SaveChangesAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _userContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _userContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _userContext.Set<T>().Update(entity);
            await _userContext.SaveChangesAsync();
        }

        
    }
}
