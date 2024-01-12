using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrganizacionesProductos.Queries
{
    public class GetOrganizacionDeailQueryHandler : IRequestHandler<GetOrganizacionDeailQuery, OrganizacionDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizacionProductoRepository _organizacionRepository;

        public GetOrganizacionDeailQueryHandler(IMapper mapper, IOrganizacionProductoRepository organizacionRepository)
        {
            _mapper = mapper;
            _organizacionRepository = organizacionRepository;
        }

        public async Task<OrganizacionDetailVM> Handle(GetOrganizacionDeailQuery request, CancellationToken cancellationToken)
        {
            var organizacion = await _organizacionRepository.GetByID(request.id);

            var organizacionDetail = _mapper.Map<OrganizacionDetailVM>(organizacion);

            return organizacionDetail;
        }
    }
}
