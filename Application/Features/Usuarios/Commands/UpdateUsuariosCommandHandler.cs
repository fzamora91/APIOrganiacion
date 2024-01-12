using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
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

            var usuarioToUpdate = await _usuarioRepository.GetByID(request.IdUsuario);

            _mapper.Map(request, usuarioToUpdate, typeof(UpdateUsuariosCommand), typeof(Usuario));


            await _usuarioRepository.UpdateAsync(usuarioToUpdate);

            return 0;

        }

       
    }
}
