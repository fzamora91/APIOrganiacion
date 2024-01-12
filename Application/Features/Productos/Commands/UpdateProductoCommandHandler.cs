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
    public class UpdateProductoCommandHandler : IRequestHandler<UpdateProductoCommand, int>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public UpdateProductoCommandHandler(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
        }

        public async Task<int> Handle(UpdateProductoCommand request, CancellationToken cancellationToken)
        {
            var productoToUpdate = await _productoRepository.GetByID(request.IdProducto);

            _mapper.Map(request, productoToUpdate, typeof(UpdateProductoCommand), typeof(Producto));

            await _productoRepository.UpdateAsync(productoToUpdate);

            return 0;
        }
    }
}
