using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Productos.Commands
{
    public class DeleteProductoCommandHandler : IRequestHandler<DeleteProductoCommand, int>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public DeleteProductoCommandHandler(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
        }

        public async Task<int> Handle(DeleteProductoCommand request, CancellationToken cancellationToken)
        {
            var productoToDelete = await _productoRepository.GetByID(request.IdProducto);
            await _productoRepository.DeleteAsync(productoToDelete);

            return 0;
        }
    }
}
