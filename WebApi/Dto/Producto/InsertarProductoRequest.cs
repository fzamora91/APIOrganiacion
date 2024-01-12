using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class InsertarProductoRequest
    {
        public string Nombre_Producto { get; set; }
        public double Precio { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public string Creado_Por { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Modificado_Por { get; set; }
        public DateTime? Ultima_Modificacion { get; set; }
    }
}
