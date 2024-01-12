using Application.Features.Productos.Commands;
using Application.Features.Productos.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto;
using WebApi.Dto.Producto;

namespace WebApi.Controllers
{
    [Authorize]
    public class ProductoController : ApiControllerBase
    {
        [HttpGet]
        public async Task<List<ProductosListVM>> Get()
        {
            return await Mediator.Send(new GetProductosListQuery());
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] InsertarProductoRequest dto)
        {
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InsertarProductoRequest, CreateProductoCommand>());
            var mapper = config.CreateMapper();

            // Crear instancia y mapear propiedades
            CreateProductoCommand createProductoCommand = mapper.Map<CreateProductoCommand>(dto);

            

            return await Mediator.Send(createProductoCommand);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Update([FromBody] ActualizarProductoRequest dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ActualizarProductoRequest, UpdateProductoCommand>());
            var mapper = config.CreateMapper();

            // Crear instancia y mapear propiedades
            UpdateProductoCommand updateProductoCommand = mapper.Map<UpdateProductoCommand>(dto);

            //CreateUsuariosCommand command = new CreateUsuariosCommand();
            return await Mediator.Send(updateProductoCommand);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Delete([FromBody] BorrarProductoRequest dto)
        {
            DeleteProductoCommand deleteUsuarioCommand = new DeleteProductoCommand();
            deleteUsuarioCommand.IdProducto = dto.id;

            return await Mediator.Send(deleteUsuarioCommand);
        }

    }
}
