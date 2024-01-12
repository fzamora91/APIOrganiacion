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
            var validator = new UpdateProductoCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0) throw new Common.ValidationException(validationResult);

            var productoToUpdate = await _productoRepository.GetByID(request.IdProducto);

            if (productoToUpdate == null)
            {
                // La entidad no existe
                throw new Exception($"No se encontró el producto con ID {request.IdProducto}");
            }

            _mapper.Map(request, productoToUpdate, typeof(UpdateProductoCommand), typeof(Producto));

            await _productoRepository.UpdateAsync(productoToUpdate);

            return 1;
        }
    }
}
