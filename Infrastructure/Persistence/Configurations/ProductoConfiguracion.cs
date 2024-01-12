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
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {

            builder.HasKey(c => c.IdProducto);
            builder.Property(c => c.Nombre_Producto).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Precio).IsRequired();
            builder.Property(c => c.Fecha_Vencimiento).IsRequired();
            builder.Property(c => c.Fecha_Creacion);
            builder.Property(c => c.Modificado_Por);
            builder.Property(c => c.Ultima_Modificacion);
        }

    }
}
