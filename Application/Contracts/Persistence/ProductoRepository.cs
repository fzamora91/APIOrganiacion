using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public class ProductoRepository : IProductoRepository
    {

        protected readonly TenantProductoDbContext _tenantProductDbContext;

        public ProductoRepository(TenantProductoDbContext tenantProductDbContext)
        {
            _tenantProductDbContext = tenantProductDbContext;
        }

        public async Task<Producto> AddAsync(Producto entity)
        {
            await _tenantProductDbContext.Set<Producto>().AddAsync(entity);
            await _tenantProductDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Producto entity)
        {
            _tenantProductDbContext.Set<Producto>().Remove(entity);
            await _tenantProductDbContext.SaveChangesAsync();
        }


        public async Task UpdateAsync(Producto entity)
        {
            _tenantProductDbContext.Set<Producto>().Update(entity);
            await _tenantProductDbContext.SaveChangesAsync();
        }

        public async Task<List<Producto>> ListAll()
        {
            return _tenantProductDbContext.Set<Producto>().ToList();
        }

        public async Task<Producto> GetByID(int id)
        {
            return await _tenantProductDbContext.Set<Producto>().FindAsync(id);
        }

        public Task<Producto> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Producto>> ListAllAsync()
        {
            return await _tenantProductDbContext.Set<Producto>().ToListAsync();
        }

        



       
    }
}
