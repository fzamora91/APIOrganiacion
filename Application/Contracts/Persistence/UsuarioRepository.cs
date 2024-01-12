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
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly TenantUsuarioDbContext _tenantUsuarioDbContext;

        public UsuarioRepository(TenantUsuarioDbContext tenantUsuarioDbContext)
        {
            _tenantUsuarioDbContext = tenantUsuarioDbContext;
        }

        public async Task<Usuario> AddAsync(Usuario entity)
        {
            await _tenantUsuarioDbContext.Set<Usuario>().AddAsync(entity);
            await _tenantUsuarioDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Usuario entity)
        {
            _tenantUsuarioDbContext.Set<Usuario>().Remove(entity);
            await _tenantUsuarioDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario entity)
        {
            _tenantUsuarioDbContext.Set<Usuario>().Update(entity);
            await _tenantUsuarioDbContext.SaveChangesAsync();
        }

        public async Task<List<Usuario>> ListAll()
        {
            return _tenantUsuarioDbContext.Set<Usuario>().ToList();
        }

        public async Task<Usuario> GetByID(int id)
        {
            return await _tenantUsuarioDbContext.Set<Usuario>().FindAsync(id);
        }

        public async Task<Usuario> GetUsuarioAutenticado(string usuario, string password)
        {
            var usuarioEncontrado = await _tenantUsuarioDbContext.Set<Usuario>().SingleOrDefaultAsync(x => x.Nombre == usuario);

            // Verificar la contraseña si se encuentra el usuario
            if (usuarioEncontrado != null && VerificarContraseña(password, usuarioEncontrado.clave))
            {
                return usuarioEncontrado;
            }

            // Retorna null si el usuario no se encuentra o la contraseña no coincide
            return null;
        }

        private bool VerificarContraseña(string contraseñaIngresada, string contraseñaAlmacenada)
        {
            return contraseñaIngresada.Equals(contraseñaAlmacenada);
        }

        public Task<Usuario> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Usuario>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

       


    }
}
