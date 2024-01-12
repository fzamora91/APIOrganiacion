using Application.Features.Usuarios.Commands;
using Application.Features.Usuarios.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto;
using WebApi.Dto.Usuario;
using WebApi.Tenant;

namespace WebApi.Controllers
{
    [Authorize]
    public class UsuarioController : ApiControllerBase
    {
        
        

        public UsuarioController()
        {
            
        }

        [HttpGet]
        public async Task<List<UsuariosListVM>> Get()
        {
            

            return await Mediator.Send(new GetUsuariosListQuery());
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]InsertarUsuarioRequest dto)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<InsertarUsuarioRequest, CreateUsuariosCommand>());
            var mapper = config.CreateMapper();

            // Crear instancia y mapear propiedades
            CreateUsuariosCommand createUsuarioCommand = mapper.Map<CreateUsuariosCommand>(dto);

            //CreateUsuariosCommand command = new CreateUsuariosCommand();
            return await Mediator.Send(createUsuarioCommand);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Update([FromBody] ActualizarUsuarioRequest dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ActualizarUsuarioRequest, UpdateUsuariosCommand>());
            var mapper = config.CreateMapper();

            // Crear instancia y mapear propiedades
            UpdateUsuariosCommand updateUsuarioCommand = mapper.Map<UpdateUsuariosCommand>(dto);

            //CreateUsuariosCommand command = new CreateUsuariosCommand();
            return await Mediator.Send(updateUsuarioCommand);

        }

        [HttpPost]
        public async Task<ActionResult<int>> Delete([FromBody] BorrarUsuarioRequest dto)
        {
            DeleteUsuariosCommand deleteUsuarioCommand = new DeleteUsuariosCommand();
            deleteUsuarioCommand.IdUsuario = dto.id;

            return await Mediator.Send(deleteUsuarioCommand);
        }

    }
}
