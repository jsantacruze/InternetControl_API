using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using business_layer.DTO;
using data_access;
using domain_layer.entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace business_layer.Suscriptores
{
    public class ConsultasHelper
    {
        public class SuscriptorQueryListRequest : IRequest<List<SuscriptorDTO>>
        {
            public string Filtro { get; set; }
        }
        public class SuscriptorQueryListHandler : IRequestHandler<SuscriptorQueryListRequest, List<SuscriptorDTO>>
        {

            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public SuscriptorQueryListHandler(InternetControlContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }
            public async Task<List<SuscriptorDTO>> Handle(SuscriptorQueryListRequest request, CancellationToken cancellationToken)
            {
                var result = await
                _context.Suscriptors
                .Include(s => s.StrIdciudadNavigation)
                .Include(s=> s.StrIdsexoNavigation)
                //.Where(s => s.CodigoSuscriptorNavigation.StrNombres.Contains(request.Filtro) 
                //|| s.CodigoSuscriptorNavigation.StrApellidos.Contains(request.Filtro))
                .ToListAsync();
                var suscriptorDTO = _mapper.Map<List<Suscriptor>, List<SuscriptorDTO>>(result);
                return suscriptorDTO;
            }
        }

    }

}