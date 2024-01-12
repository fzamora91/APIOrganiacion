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

namespace Application.Features.OrganizacionesProductos.Commands
{
    public class UpdateOrganizacionCommandHandler : IRequestHandler<UpdateOrganizacionCommand, int>
    {
        private readonly IOrganizacionProductoRepository _organizacionProductoRepository;
        private readonly IMapper _mapper;

        public UpdateOrganizacionCommandHandler(IMapper mapper, IOrganizacionProductoRepository organizacionProductoRepository)
        {
            _mapper = mapper;
            _organizacionProductoRepository = organizacionProductoRepository;
        }

        public async Task<int> Handle(UpdateOrganizacionCommand request, CancellationToken cancellationToken)
        {

            var organizacionToUpdate = await _organizacionProductoRepository.GetByID(request.IdOrganizacion);

            _mapper.Map(request, organizacionToUpdate, typeof(UpdateOrganizacionCommand), typeof(Organizacion));

            await _organizacionProductoRepository.UpdateAsync(organizacionToUpdate);

            return 0;

        }
    }
}
