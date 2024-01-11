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

namespace Application.Features.Productos.Queries
{
    public class GetProductosListQueryHandler : IRequestHandler<GetProductosListQuery, List<ProductosListVM>>
    {

        //private readonly IBaseRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;

        public GetProductosListQueryHandler(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
        }


        public async Task<List<ProductosListVM>> Handle(GetProductosListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = (await _productoRepository.ListAll()).OrderBy(x => x.Fecha_Vencimiento);


            return _mapper.Map<List<ProductosListVM>>(allProducts);
            
        }
    }
}
