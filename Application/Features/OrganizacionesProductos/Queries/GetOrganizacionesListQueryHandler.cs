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
    public class GetOrganizacionesListQueryHandler : IRequestHandler<GetOrganizacionesListQuery, List<OrganizacionesListVM>>
    {
    
        private readonly IMapper _mapper;
        private readonly IOrganizacionProductoRepository _organizacionRepository;

        public GetOrganizacionesListQueryHandler(IMapper mapper, IOrganizacionProductoRepository organizacionRepository)
        {
            _mapper = mapper;
            _organizacionRepository = organizacionRepository;
        }

        public async Task<List<OrganizacionesListVM>> Handle(GetOrganizacionesListQuery request, CancellationToken cancellationToken)
        {
            var allOrganizaciones = (await _organizacionRepository.ListAll()).OrderBy(x => x.IdOrganizacion);


            return _mapper.Map<List<OrganizacionesListVM>>(allOrganizaciones);
        }
    }
}
