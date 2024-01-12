using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<List<Usuario>> ListAll();
        Task<Usuario> GetByID(int id);
        Task<Usuario> GetUsuarioAutenticado(string usuario, string password);
    }
}
