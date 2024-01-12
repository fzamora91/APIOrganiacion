using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class OrganizacionConfiguracion : IEntityTypeConfiguration<Organizacion>
    {
        public void Configure(EntityTypeBuilder<Organizacion> builder)
        {

            builder.HasKey(c => c.IdOrganizacion);
            builder.Property(c => c.Nombre);
            builder.Property(c => c.Pais);
            builder.Property(c => c.Direccion);
            builder.Property(c => c.SitioWeb);
            builder.Property(c => c.telefono).HasMaxLength(30);
            builder.Property(c => c.email);

        }
    }
}
