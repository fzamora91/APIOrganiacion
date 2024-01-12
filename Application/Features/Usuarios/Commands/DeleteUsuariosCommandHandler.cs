using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Commands
{
    public class DeleteUsuariosCommandHandler : IRequestHandler<DeleteUsuariosCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public DeleteUsuariosCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(DeleteUsuariosCommand request, CancellationToken cancellationToken)
        {
            var usuarioToDelete = await _usuarioRepository.GetByID(request.IdUsuario);
            await _usuarioRepository.DeleteAsync(usuarioToDelete);

            return 0;
        }
    }
}
