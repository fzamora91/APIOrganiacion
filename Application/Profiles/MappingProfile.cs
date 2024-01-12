using Application.Features;
using Application.Features.Productos.Commands;
using Application.Features.Productos.Queries;
using Application.Features.Usuarios.Commands;
using Application.Features.Usuarios.Queries;
using Application.Features.Usuarios.Queries.GetUsuarioAutenticado;
using Application.Features.Usuarios.Queries.GetUsuarioDetail;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Organizacion, Features.OrganizacionesUsuarios.Queries.OrganizacionesListVM>().ReverseMap();
            CreateMap<Organizacion, Features.OrganizacionesProductos.Queries.OrganizacionesListVM>().ReverseMap();

            CreateMap<Usuario, UsuariosListVM>().ReverseMap();
            CreateMap<Producto, ProductosListVM>().ReverseMap();

            CreateMap<Usuario, UsuarioAutenticadoVm>().ReverseMap();




            CreateMap<Organizacion, Features.OrganizacionesUsuarios.Queries.OrganizacionDetailVM>().ReverseMap();
            CreateMap<Organizacion, Features.OrganizacionesProductos.Queries.OrganizacionDetailVM>().ReverseMap();

            CreateMap<Usuario, UsuarioDetailVM>().ReverseMap();
            CreateMap<Producto, Features.Productos.Queries.GetProductoDetail.ProductoDetailVM>().ReverseMap();


            CreateMap<Organizacion, Features.OrganizacionesUsuarios.Commands.CreateOrganizacionCommand>().ReverseMap();
            CreateMap<Organizacion, Features.OrganizacionesProductos.Commands.CreateOrganizacionCommand>().ReverseMap();

            CreateMap<Usuario, CreateUsuariosCommand>().ReverseMap();
            CreateMap<Producto, CreateProductoCommand>().ReverseMap();



            CreateMap<Organizacion, Features.OrganizacionesUsuarios.Commands.UpdateOrganizacionCommand>().ReverseMap();
            CreateMap<Organizacion, Features.OrganizacionesProductos.Commands.UpdateOrganizacionCommand>().ReverseMap();


            CreateMap<Usuario, UpdateUsuariosCommand>().ReverseMap();
            CreateMap<Producto, UpdateProductoCommand>().ReverseMap();


            CreateMap<Organizacion, Features.OrganizacionesUsuarios.Commands.DeleteOrganizacionCommand>().ReverseMap();
            CreateMap<Organizacion, Features.OrganizacionesProductos.Commands.DeleteOrganizacionCommand>().ReverseMap();

            CreateMap<Usuario, DeleteUsuariosCommand>().ReverseMap();
            CreateMap<Producto, DeleteProductoCommand>().ReverseMap();




            //CreateMap<AuthRequest,AuthCommand>().ReverseMap();

            //CreateMap<AuthResponseDTO, AuthCommand>().ReverseMap();
        }
    }
}
