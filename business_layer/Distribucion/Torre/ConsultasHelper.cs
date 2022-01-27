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

namespace business_layer.Distribucion.Torre
{
    public class ConsultasHelper
    {
        public class TorreDistribucionQueryListRequest: IRequest<List<TorreDistribucionDTO>>{
            public string ubicacion_id {get; set;}
        }

        public class TorreDistribucionQueryListHandler : IRequestHandler<TorreDistribucionQueryListRequest, List<TorreDistribucionDTO>>
        {
            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public TorreDistribucionQueryListHandler(InternetControlContext context, IMapper mapper){
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<TorreDistribucionDTO>> Handle(TorreDistribucionQueryListRequest request, CancellationToken cancellationToken)
            {
                var torresList = new List<TorreDistribucion>();
                if(request.ubicacion_id.Trim() != "")
                {
                    torresList = await 
                    _context.TorreDistribucions
                    .Include(t => t.TorreUbicacion)
                    .Include(t => t.PuntoAccesoServicios)
                    .Where(t => t.TorreUbicacionId == request.ubicacion_id)
                    .ToListAsync();
                }
                else{

                    torresList = await 
                    _context.TorreDistribucions
                    .Include(t => t.TorreUbicacion)
                    .Include(t => t.PuntoAccesoServicios)
                    .ToListAsync();
                }
                var torresListDTO = _mapper.Map<List<TorreDistribucion>, List<TorreDistribucionDTO>>(torresList);
                return torresListDTO;
            }
        }

    }
}