using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Queries
{
    public class GetUsuariosListQueryHandler : IRequestHandler<GetUsuariosListQuery, List<UsuariosListVM>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;


        public GetUsuariosListQueryHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }


        public async Task<List<UsuariosListVM>> Handle(GetUsuariosListQuery request, CancellationToken cancellationToken)
        {
            var allUsers = (await _usuarioRepository.ListAll()).OrderBy(x => x.Ultima_sesion);

            return _mapper.Map<List<UsuariosListVM>>(allUsers);
        }


    }
}
