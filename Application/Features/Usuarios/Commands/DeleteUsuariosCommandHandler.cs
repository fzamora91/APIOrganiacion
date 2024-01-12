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
            var validator = new DeleteUsuariosCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0) throw new Common.ValidationException(validationResult);

            var usuarioToDelete = await _usuarioRepository.GetByID(request.IdUsuario);

            if (usuarioToDelete == null)
            {
                // La entidad no existe
                throw new Exception($"No se encontró el usuario con ID {request.IdUsuario}");
            }

            await _usuarioRepository.DeleteAsync(usuarioToDelete);

            return 1;
        }
    }
}
