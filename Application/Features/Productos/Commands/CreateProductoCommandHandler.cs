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

namespace Application.Features.Productos.Commands
{
    public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, int>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;


        public CreateProductoCommandHandler(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
        }

        public async Task<int> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var @producto = _mapper.Map<Producto>(request);
            @producto = await _productoRepository.AddAsync(@producto);
            return producto.IdProducto;
        }

    }
}
