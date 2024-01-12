using Application.Features.OrganizacionesUsuarios.Commands;
using Application.Features.OrganizacionesUsuarios.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Dto;
using WebApi.Dto.Organizacion;

namespace WebApi.Areas
{
    [Authorize]
    public class OrganizacionController : ApiControllerBase
    {

        // GET
        [HttpGet]
        public async Task<List<Application.Features.OrganizacionesUsuarios.Queries.OrganizacionesListVM>> GetOrgUsuarios()
        {
            return await Mediator.Send(new Application.Features.OrganizacionesUsuarios.Queries.GetOrganizacionesListQuery());
        }

        /*[HttpGet]
        public async Task<List<Application.Features.OrganizacionesProductos.Queries.OrganizacionesListVM>> GetOrgPruductos()
        {
            return await Mediator.Send(new Application.Features.OrganizacionesProductos.Queries.GetOrganizacionesListQuery());
        }*/



        //POST
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrgUsuario([FromBody] InsertarOrganizacionRequest dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InsertarOrganizacionRequest, CreateOrganizacionCommand>());
            var mapper = config.CreateMapper();

            // Crear instancia y mapear propiedades
            CreateOrganizacionCommand createOrganizacionCommand = mapper.Map<CreateOrganizacionCommand>(dto);

            return await Mediator.Send(createOrganizacionCommand);
        }

        [HttpPost]
        public async Task<ActionResult<int>> UpdateOrgUsuario([FromBody] ActualizarOrganizacionRequest dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ActualizarOrganizacionRequest, UpdateOrganizacionCommand>());
            var mapper = config.CreateMapper();

            // Crear instancia y mapear propiedades
            UpdateOrganizacionCommand updateOrganizacionCommand = mapper.Map<UpdateOrganizacionCommand>(dto);

            return await Mediator.Send(updateOrganizacionCommand);
        }


        [HttpPost]
        public async Task<ActionResult<int>> DeleteOrgUsuario([FromBody] BorrarOrganizacioRequest dto)
        {
            DeleteOrganizacionCommand deleteOrganizacionCommand = new DeleteOrganizacionCommand();
            deleteOrganizacionCommand.IdOrganizacion = dto.id;

            return await Mediator.Send(deleteOrganizacionCommand);
        }


    }
}
