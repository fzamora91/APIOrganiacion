using Application.Features.OrganizacionesUsuarios.Commands;
using Application.Features.OrganizacionesUsuarios.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Dto;
using WebApi.Dto.Organizacion;
using WebApi.Tenant;

namespace WebApi.Areas
{
    [Authorize]
    public class OrganizacionController : ApiControllerBase
    {

        private readonly ITenantSetter tenantSetter;

        public OrganizacionController(ITenantSetter tenantSetter)
        {
            this.tenantSetter = tenantSetter;
        }


        // GET
        [HttpGet]
        public async Task<ActionResult> GetOrgUsuarios()
        {
            var tenant = (TenantService)tenantSetter;
            

            List<Application.Features.OrganizacionesUsuarios.Queries.OrganizacionesListVM> listOrganizacionesUsuarios = new List<OrganizacionesListVM>();

            List<Application.Features.OrganizacionesProductos.Queries.OrganizacionesListVM> listOrganizacionesProductos = new List<Application.Features.OrganizacionesProductos.Queries.OrganizacionesListVM>();

            if (tenant.Tenant.Equals("OrganizacionUsuario"))
            {
                listOrganizacionesUsuarios = await Mediator.Send(new Application.Features.OrganizacionesUsuarios.Queries.GetOrganizacionesListQuery());
                return Ok(listOrganizacionesUsuarios);
            }
            else
            {
                listOrganizacionesProductos = await Mediator.Send(new Application.Features.OrganizacionesProductos.Queries.GetOrganizacionesListQuery());
                return Ok(listOrganizacionesProductos);
            }

            
        }

        //POST
        [HttpPost]
        public async Task<ActionResult<int>> CreateOrgUsuario([FromBody] InsertarOrganizacionRequest dto)
        {

            var tenant = (TenantService)tenantSetter;

            if (tenant.Tenant.Equals("OrganizacionUsuario"))
            {

                var config = new MapperConfiguration(cfg => cfg.CreateMap<InsertarOrganizacionRequest, CreateOrganizacionCommand>());
                var mapper = config.CreateMapper();

                // Crear instancia y mapear propiedades
                CreateOrganizacionCommand createOrganizacionCommand = mapper.Map<CreateOrganizacionCommand>(dto);
                return  Ok(Mediator.Send(createOrganizacionCommand));
                
            }
            else
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<InsertarOrganizacionRequest, Application.Features.OrganizacionesProductos.Commands.CreateOrganizacionCommand>());
                var mapper = config.CreateMapper();

                // Crear instancia y mapear propiedades
                Application.Features.OrganizacionesProductos.Commands.CreateOrganizacionCommand createOrganizacionCommand = mapper.Map<Application.Features.OrganizacionesProductos.Commands.CreateOrganizacionCommand>(dto);
                return Ok(Mediator.Send(createOrganizacionCommand));
            }


            
        }

        [HttpPost]
        public async Task<ActionResult<int>> UpdateOrgUsuario([FromBody] ActualizarOrganizacionRequest dto)
        {
            var tenant = (TenantService)tenantSetter;

            if (tenant.Tenant.Equals("OrganizacionUsuario"))
            {

                var config = new MapperConfiguration(cfg => cfg.CreateMap<ActualizarOrganizacionRequest, UpdateOrganizacionCommand>());
                var mapper = config.CreateMapper();

                // Crear instancia y mapear propiedades
                UpdateOrganizacionCommand updateOrganizacionCommand = mapper.Map<UpdateOrganizacionCommand>(dto);

                var result = await Mediator.Send(updateOrganizacionCommand);

                return Ok(result);
            }
            else
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ActualizarOrganizacionRequest, Application.Features.OrganizacionesProductos.Commands.UpdateOrganizacionCommand>());
                var mapper = config.CreateMapper();

                // Crear instancia y mapear propiedades
                Application.Features.OrganizacionesProductos.Commands.UpdateOrganizacionCommand updateOrganizacionCommand = mapper.Map<Application.Features.OrganizacionesProductos.Commands.UpdateOrganizacionCommand>(dto);

                var result = await Mediator.Send(updateOrganizacionCommand);

                return Ok(result);
            }

           

           
        }


        [HttpPost]
        public async Task<ActionResult<int>> DeleteOrgUsuario([FromBody] BorrarOrganizacioRequest dto)
        {
            var tenant = (TenantService)tenantSetter;
            if (tenant.Tenant.Equals("OrganizacionUsuario"))
            {
                DeleteOrganizacionCommand deleteOrganizacionCommand = new DeleteOrganizacionCommand();
                deleteOrganizacionCommand.IdOrganizacion = dto.id;
                return await Mediator.Send(deleteOrganizacionCommand);
            }
            else
            {
                Application.Features.OrganizacionesProductos.Commands.DeleteOrganizacionCommand deleteOrganizacionCommand = new Application.Features.OrganizacionesProductos.Commands.DeleteOrganizacionCommand();
                deleteOrganizacionCommand.IdOrganizacion = dto.id;
                return await Mediator.Send(deleteOrganizacionCommand);
            }



             
        }


    }


    
}
