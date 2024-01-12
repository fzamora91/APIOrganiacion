using AutoMapper;
using Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;

namespace Application.Features.OrganizacionesUsuarios.Queries
{
    public class GetOrganizacionDeailQueryHandler : IRequestHandler<GetOrganizacionDeailQuery, OrganizacionDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IOrganizacionUsuarioRepository _organizacionRepository;

        public GetOrganizacionDeailQueryHandler(IMapper mapper, IOrganizacionUsuarioRepository organizacionRepository)
        {
            _mapper = mapper;
            _organizacionRepository = organizacionRepository;
        }

        public async Task<OrganizacionDetailVM> Handle(GetOrganizacionDeailQuery request, CancellationToken cancellationToken)
        {
            var organizacion = _organizacionRepository.GetByID(request.id);

            var organizacionDetail = _mapper.Map<OrganizacionDetailVM>(organizacion);

            return organizacionDetail;
        }
    }
}
