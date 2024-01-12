using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.Producto
{
    public class ActualizarProductoRequest
    {
        public int IdProducto { get; set; }
        public string Nombre_Producto { get; set; }
        public double Precio { get; set; }
        public DateTime? Fecha_Vencimiento { get; set; } = null;
        public string Creado_Por { get; set; }
        public DateTime? Fecha_Creacion { get; set; } = null;
        public string Modificado_Por { get; set; }
        public DateTime? Ultima_Modificacion { get; set; } = null;
    }
}
