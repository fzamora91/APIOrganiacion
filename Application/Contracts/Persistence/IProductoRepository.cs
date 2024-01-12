using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IProductoRepository : IBaseRepository<Producto>
    {

        Task<List<Producto>> ListAll();
        Task<Producto> GetByID(int id);
    }
}
