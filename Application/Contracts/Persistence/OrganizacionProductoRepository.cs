using Domain.Entities;
using Infrastructure.Migrations;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
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
             _tenantProductDbContext.SaveChanges();

            _tenantProductDbContext.actualizarMigracion();
            return entity;
        }

        public  Task UpdateAsync(Organizacion entity)
        {
            _tenantProductDbContext.Set<Organizacion>().Update(entity);

            var resultado =  _tenantProductDbContext.SaveChangesAsync();
            return resultado;

           // return _tenantProductDbContext.SaveChangesAsync();
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

        public Organizacion GetByID(int id)
        {
            var organizacion = _tenantProductDbContext.Set<Organizacion>().Find(id);

            return organizacion;
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
