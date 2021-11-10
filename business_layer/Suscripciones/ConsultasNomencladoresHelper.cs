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
    public class ConsultasNomencladoresHelper
    {
        //TIPOS DE SUSCRIPCION
        public class TipoSuscripcionQueryListRequest: IRequest<List<TipoSuscripcionDTO>>{
        }
        
        public class TipoSuscripcionQueryListHandler: IRequestHandler<TipoSuscripcionQueryListRequest, List<TipoSuscripcionDTO>>{
            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public TipoSuscripcionQueryListHandler(InternetControlContext context, IMapper mapper){
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<TipoSuscripcionDTO>> Handle(TipoSuscripcionQueryListRequest request, CancellationToken cancellationToken){
                var result = await 
                _context.TipoSuscripcions
                .OrderBy(o => o.TipoDescripcion)
                .ToListAsync();
                var resultDTO = _mapper.Map<List<TipoSuscripcion>, List<TipoSuscripcionDTO>>(result);
                return resultDTO;
            }
        }

        //ESTADOS DE SUSCRIPCION
        public class EstadoSuscripcionQueryListRequest: IRequest<List<EstadoSuscripcionDTO>>{
        }
        
        public class EstadoSuscripcionQueryListHandler: IRequestHandler<EstadoSuscripcionQueryListRequest, List<EstadoSuscripcionDTO>>{
            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public EstadoSuscripcionQueryListHandler(InternetControlContext context, IMapper mapper){
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<EstadoSuscripcionDTO>> Handle(EstadoSuscripcionQueryListRequest request, CancellationToken cancellationToken){
                var result = await 
                _context.EstadoSuscripcions
                .OrderBy(o => o.DescripcionEstadoSuscripcion)
                .ToListAsync();
                var resultDTO = _mapper.Map<List<EstadoSuscripcion>, List<EstadoSuscripcionDTO>>(result);
                return resultDTO;
            }
        }

        //SECTOR CIUDAD
        public class SectorCiudadQueryListRequest: IRequest<List<SectorCiudadDTO>>{
        }
        
        public class SectorCiudadQueryListHandler: IRequestHandler<SectorCiudadQueryListRequest, List<SectorCiudadDTO>>{
            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public SectorCiudadQueryListHandler(InternetControlContext context, IMapper mapper){
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<SectorCiudadDTO>> Handle(SectorCiudadQueryListRequest request, CancellationToken cancellationToken){
                var result = await 
                _context.SectorCiudads
                .OrderBy(o => o.DescripcionSector)
                .ToListAsync();
                var resultDTO = _mapper.Map<List<SectorCiudad>, List<SectorCiudadDTO>>(result);
                return resultDTO;
            }
        }

        //PUNTO DE ACCESO SERVICIO
        public class PuntoAccesoServicioQueryListRequest: IRequest<List<PuntoAccesoServicioDTO>>{
        }
        
        public class PuntoAccesoServicioQueryListHandler: IRequestHandler<PuntoAccesoServicioQueryListRequest, List<PuntoAccesoServicioDTO>>{
            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public PuntoAccesoServicioQueryListHandler(InternetControlContext context, IMapper mapper){
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<PuntoAccesoServicioDTO>> Handle(PuntoAccesoServicioQueryListRequest request, CancellationToken cancellationToken){
                var result = await 
                _context.PuntoAccesoServicios
                .OrderBy(o => o.Descripcion)
                .ToListAsync();
                var resultDTO = _mapper.Map<List<PuntoAccesoServicio>, List<PuntoAccesoServicioDTO>>(result);
                return resultDTO;
            }
        }


        

    }
}