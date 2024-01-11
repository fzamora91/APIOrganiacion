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

namespace Application.Features.OrganizacionesUsuarios.Commands
{
    public class CreateOrganizacionCommandHandler : IRequestHandler<CreateOrganizacionCommand, int>
    {
        private readonly IOrganizacionUsuarioRepository _organizacionRepository;
        private readonly IMapper _mapper;


        public CreateOrganizacionCommandHandler(IMapper mapper, IOrganizacionUsuarioRepository organizacionRepository)
        {
            _mapper = mapper;
            _organizacionRepository = organizacionRepository;
        }

        public async Task<int> Handle(CreateOrganizacionCommand request, CancellationToken cancellationToken)
        {
            var @organizacion = _mapper.Map<Organizacion>(request);
            @organizacion = await _organizacionRepository.AddAsync(@organizacion);
            return @organizacion.IdOrganizacion;
        }
    }
}
