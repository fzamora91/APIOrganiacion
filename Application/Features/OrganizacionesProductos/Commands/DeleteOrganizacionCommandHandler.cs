using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrganizacionesProductos.Commands
{
    public class DeleteOrganizacionCommandHandler : IRequestHandler<DeleteOrganizacionCommand, int>
    {
        private readonly IOrganizacionProductoRepository _organizacionProductoRepository;
        private readonly IMapper _mapper;

        public DeleteOrganizacionCommandHandler(IMapper mapper, IOrganizacionProductoRepository organizacionProductoRepository)
        {
            _mapper = mapper;
            _organizacionProductoRepository = organizacionProductoRepository;
        }

        public async Task<int> Handle(DeleteOrganizacionCommand request, CancellationToken cancellationToken)
        {

            var validator = new DeleteOrganizacionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0) throw new Common.ValidationException(validationResult);


            var organizacionToDelete = _organizacionProductoRepository.GetByID(request.IdOrganizacion);

            if (organizacionToDelete == null)
            {
                // La entidad no existe
                throw new Exception($"No se encontró la organización con ID {request.IdOrganizacion}");
            }

            await _organizacionProductoRepository.DeleteAsync(organizacionToDelete);

            return 1;
        }
    }
}
