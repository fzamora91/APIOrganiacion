using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrganizacionesUsuarios.Commands
{
    public class DeleteOrganizacionCommandHandler : IRequestHandler<DeleteOrganizacionCommand, int>
    {
        private readonly IOrganizacionUsuarioRepository _organizacionUsuarioRepository;
        private readonly IMapper _mapper;


        public DeleteOrganizacionCommandHandler(IMapper mapper, IOrganizacionUsuarioRepository organizacionUsuarioRepository)
        {
            _mapper = mapper;
            _organizacionUsuarioRepository = organizacionUsuarioRepository;
        }

        public async Task<int> Handle(DeleteOrganizacionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteOrganizacionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0) throw new Common.ValidationException(validationResult);

            var organizacionToDelete = _organizacionUsuarioRepository.GetByID(request.IdOrganizacion);

            if (organizacionToDelete == null)
            {
                // La entidad no existe, puedes lanzar una excepción adecuada
                throw new Exception($"No se encontró la organización con ID {request.IdOrganizacion}");
            }

            await _organizacionUsuarioRepository.DeleteAsync(organizacionToDelete);

            return 0;
        }
    }
}
