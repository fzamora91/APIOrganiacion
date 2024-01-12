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
            var organizacionToDelete = await _organizacionProductoRepository.GetByID(request.IdOrganizacion);
            await _organizacionProductoRepository.DeleteAsync(organizacionToDelete);

            return 0;
        }
    }
}
