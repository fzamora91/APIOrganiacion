using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Productos.Queries.GetProductoDetail
{
    public class GetProductoDeailQueryHandler : IRequestHandler<GetProductoDeailQuery, ProductoDetailVM>
    {

        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;

        public GetProductoDeailQueryHandler(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
        }


        public async Task<ProductoDetailVM> Handle(GetProductoDeailQuery request, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetByID(request.id);

            var productoDetail = _mapper.Map<ProductoDetailVM>(producto);

            return productoDetail;
        }
    }
}
