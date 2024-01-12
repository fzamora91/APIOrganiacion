using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public class OrganizacionProductoRepository : IOrganizacionProductoRepository
    {
        protected readonly TenantProductoDbContext _tenantProductDbContext;

        public OrganizacionProductoRepository(TenantProductoDbContext tenantProductDbContext)
        {
            _tenantProductDbContext = tenantProductDbContext;
        }

        public async Task<Organizacion> AddAsync(Organizacion entity)
        {
            await _tenantProductDbContext.Set<Organizacion>().AddAsync(entity);
            await _tenantProductDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Organizacion entity)
        {
            _tenantProductDbContext.Set<Organizacion>().Update(entity);
            await _tenantProductDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Organizacion entity)
        {
            _tenantProductDbContext.Set<Organizacion>().Remove(entity);
            await _tenantProductDbContext.SaveChangesAsync();
        }


        public async Task<List<Organizacion>> ListAll()
        {
            return _tenantProductDbContext.Set<Organizacion>().ToList();
        }

        public async Task<Organizacion> GetByID(int id)
        {
            return await _tenantProductDbContext.Set<Organizacion>().FindAsync(id);
        }


        public Task<Organizacion> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Organizacion>> ListAllAsync()
        {
            throw new NotImplementedException();
        }


    }
}
