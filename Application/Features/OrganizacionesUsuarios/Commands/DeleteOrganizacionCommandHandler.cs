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
            var organizacionToDelete = await _organizacionUsuarioRepository.GetByID(request.IdOrganizacion);
            await _organizacionUsuarioRepository.DeleteAsync(organizacionToDelete);

            return 0;
        }
    }
}
