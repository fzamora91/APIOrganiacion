using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDeailQueryHandler : IRequestHandler<GetUsuarioDeailQuery, UsuarioDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public GetUsuarioDeailQueryHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDetailVM> Handle(GetUsuarioDeailQuery request, CancellationToken cancellationToken)
        {
            var usuaio = await _usuarioRepository.GetByID(request.id);

            var usuarioDetail = _mapper.Map<UsuarioDetailVM>(usuaio);

            return usuarioDetail;
        }
    }
}
