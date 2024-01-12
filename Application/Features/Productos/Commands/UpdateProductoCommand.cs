﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Productos.Commands
{
    public class UpdateProductoCommand: IRequest<int>
    {
        public int IdProducto { get; set; }
        public string Nombre_Producto { get; set; }
        public double Precio { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public string Creado_Por { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public string Modificado_Por { get; set; }
        public DateTime? Ultima_Modificacion { get; set; }
    }
}
