using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Queries.GetUsuarioAutenticado
{
    public class GetUsuarioAutenticadoQueryHandler : IRequestHandler<GetUsuarioAutenticadoQuery, UsuarioAutenticadoVm>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public GetUsuarioAutenticadoQueryHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioAutenticadoVm> Handle(GetUsuarioAutenticadoQuery request, CancellationToken cancellationToken)
        {
            var usuaio = await _usuarioRepository.GetUsuarioAutenticado(request.usuario, request.clave);

            var usuarioDetail = _mapper.Map<UsuarioAutenticadoVm>(usuaio);

            return usuarioDetail;
        }
    }
}
