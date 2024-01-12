using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class TenantUsuarioDbContextFactory : IDesignTimeDbContextFactory<TenantUsuarioDbContext>
    {
        public TenantUsuarioDbContext CreateDbContext(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<TenantUsuarioDbContext>(options =>
                    options.UseSqlServer("Tu cadena de conexión aquí"))
                .BuildServiceProvider();

            return serviceProvider.GetRequiredService<TenantUsuarioDbContext>();
        }
    }
    
}
