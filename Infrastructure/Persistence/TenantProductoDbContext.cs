using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Domain.Entities;
using System.Reflection;
using System.Threading;
using Infrastructure.Identity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.Extensions.Options;
using MediatR;

namespace Infrastructure.Persistence
{
    public class TenantProductoDbContext : DbContext
    {
        //private readonly IMediator _mediator;
        //private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;


        public TenantProductoDbContext() 
        {
            //_mediator = mediator;
            //_auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;

        }

        //public DbSet<Usuario> Usuario => Set<Usuario>();
        public DbSet<Producto> Producto => Set<Producto>();
        public DbSet<Organizacion> Organizacion => Set<Organizacion>();



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //Persist Security Info = False; User ID = sa; Password = sa1403; Initial Catalog = DB_Tecnan01; Server = MySqlServer

            //"Data Source=DESKTOP-D5MIIT4;Initial Catalog=DB_Tecnan01; User Id = sa; Password = sa1403; Encrypt=True;TrustServerCertificate=False; Pooling= true; Connection Timeout=30;"

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-D5MIIT4;Initial Catalog=DB_Tecnan02; User Id = sa; Password = sa1403; Encrypt=False;TrustServerCertificate=False; Pooling= true; Connection Timeout=30;");
            

        }

    }
}
