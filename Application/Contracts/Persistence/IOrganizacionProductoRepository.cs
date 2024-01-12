using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IOrganizacionProductoRepository : IBaseRepository<Organizacion>
    {
        Task<List<Organizacion>> ListAll();
        Organizacion GetByID(int id);
    }
}
