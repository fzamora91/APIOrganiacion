using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Commands
{
    public class UpdateUsuariosCommandHandler : IRequestHandler<UpdateUsuariosCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;


        public UpdateUsuariosCommandHandler(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(UpdateUsuariosCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUsuariosCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0) throw new Common.ValidationException(validationResult);

            var usuarioToUpdate = await _usuarioRepository.GetByID(request.IdUsuario);

            if (usuarioToUpdate == null)
            {
                // La entidad no existe
                throw new Exception($"No se encontró el usuario con ID {request.IdUsuario}");
            }

            _mapper.Map(request, usuarioToUpdate, typeof(UpdateUsuariosCommand), typeof(Usuario));


            await _usuarioRepository.UpdateAsync(usuarioToUpdate);

            return 1;

        }

       
    }
}
