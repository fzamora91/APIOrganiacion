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

namespace Application.Features.Usuarios.Commands
{
    public class CreateUsuariosCommandHandler : IRequestHandler<CreateUsuariosCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;


        public CreateUsuariosCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(CreateUsuariosCommand request, CancellationToken cancellationToken)
        {
            var @usuario = _mapper.Map<Usuario>(request);
            @usuario = await _usuarioRepository.AddAsync(@usuario);
            return @usuario.IdUsuario;
        }
    }
}
