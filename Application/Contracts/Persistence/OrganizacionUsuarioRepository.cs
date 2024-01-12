using Domain.Entities;
using Infrastructure.Migrations;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
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
            _tenantUsuarioDbContext.SaveChangesAsync();

            _tenantUsuarioDbContext.actualizarMigracion();

            return entity;
        }

        public async Task DeleteAsync(Organizacion entity)
        {
            _tenantUsuarioDbContext.Set<Organizacion>().Remove(entity);
            await _tenantUsuarioDbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Organizacion entity)
        {
            _tenantUsuarioDbContext.Set<Organizacion>().Update(entity);
            var resultado =  _tenantUsuarioDbContext.SaveChangesAsync();
            return resultado;
            
        }

        public async Task<List<Organizacion>> ListAll()
        {
            return _tenantUsuarioDbContext.Set<Organizacion>().ToList();
        }

        public Organizacion GetByID(int id)
        {
            return _tenantUsuarioDbContext.Set<Organizacion>().Find(id);
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
