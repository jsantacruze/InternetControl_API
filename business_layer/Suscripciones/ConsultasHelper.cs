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

namespace business_layer.Suscripciones
{
    public class ConsultasHelper
    {
        public class SuscripcionQueryListRequest: IRequest<List<SuscripcionDTO>>{
            public string Filtro {get; set;}
        }

        public class SuscripcionQueryListHandler: IRequestHandler<SuscripcionQueryListRequest, List<SuscripcionDTO>> {

            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public SuscripcionQueryListHandler(InternetControlContext context, IMapper mapper){
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<SuscripcionDTO>> Handle(SuscripcionQueryListRequest request, CancellationToken cancellationToken){
                var suscripcionesList = await 
                _context.Suscripcions
                .Include(s => s.CodigoSuscriptorNavigation)
                .Include(s => s.TrackingSuscripcions)
                .Include(s => s.ImagenSuscripcions)
                .Where(s => s.CodigoSuscriptorNavigation.StrNombres.Contains(request.Filtro) 
                || s.CodigoSuscriptorNavigation.StrApellidos.Contains(request.Filtro))
                .ToListAsync();
                var suscripcionesDTO = _mapper.Map<List<Suscripcion>, List<SuscripcionDTO>>(suscripcionesList);
                return suscripcionesDTO;
            }
        }
    }
}