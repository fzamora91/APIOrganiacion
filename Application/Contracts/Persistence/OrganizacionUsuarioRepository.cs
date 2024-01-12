using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public class OrganizacionUsuarioRepository : IOrganizacionUsuarioRepository
    {
        protected readonly TenantUsuarioDbContext _tenantUsuarioDbContext;

        public OrganizacionUsuarioRepository(TenantUsuarioDbContext tenantUsuarioDbContext)
        {
            _tenantUsuarioDbContext = tenantUsuarioDbContext;
        }


        public async Task<Organizacion> AddAsync(Organizacion entity)
        {
            await _tenantUsuarioDbContext.Set<Organizacion>().AddAsync(entity);
            await _tenantUsuarioDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Organizacion entity)
        {
            _tenantUsuarioDbContext.Set<Organizacion>().Remove(entity);
            await _tenantUsuarioDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Organizacion entity)
        {
            _tenantUsuarioDbContext.Set<Organizacion>().Update(entity);
            await _tenantUsuarioDbContext.SaveChangesAsync();
        }

        public async Task<List<Organizacion>> ListAll()
        {
            return _tenantUsuarioDbContext.Set<Organizacion>().ToList();
        }

        public async Task<Organizacion> GetByID(int id)
        {
            return await _tenantUsuarioDbContext.Set<Organizacion>().FindAsync(id);
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
