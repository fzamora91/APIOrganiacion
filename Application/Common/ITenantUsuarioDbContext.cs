using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public interface ITenantUsuarioDbContext
    {
        DbSet<Usuario> Usuario { get; }
        //DbSet<Producto> Producto { get; }
        DbSet<Organizacion> Organizacion { get; }
    }
}
