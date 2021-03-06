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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace business_layer.Suscripciones
{
    public class ConsultasHelper
    {
        //POR ID
        public class SuscripcionQueryByIDRequest: IRequest<SuscripcionDTO>{
            public long id {get; set;}
        }

        public class SuscripcionQueryByIDHandler: IRequestHandler<SuscripcionQueryByIDRequest, SuscripcionDTO> {

            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public SuscripcionQueryByIDHandler(InternetControlContext context, IMapper mapper){
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<SuscripcionDTO> Handle(SuscripcionQueryByIDRequest request, CancellationToken cancellationToken){
                var suscripcionResult = await 
                _context.Suscripcions
                .Include(s => s.TipoSuscripcion)
                .Include(s => s.IdpuntoAccesoNavigation)
                .Include(s => s.CodigoSuscriptorNavigation)
                .Include(s => s.TrackingSuscripcions)
                .Include(s => s.ImagenSuscripcions)
                .Include(s => s.StrIdsectorNavigation)
                .Where(s => s.DblCodigoSuscripcion == request.id
                        )
                .FirstOrDefaultAsync();
                var suscripcionDTO = _mapper.Map<Suscripcion, SuscripcionDTO>(suscripcionResult);
                return suscripcionDTO;
            }
        }

        //POR FILTRO
        public class SuscripcionQueryListRequest: IRequest<List<SuscripcionDTO>>{
            public string Filtro {get; set;}
            public string TipoFiltro {get; set;} //"1": NOMBRES APELLIDOS  2: CEDULA 
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
                .Include(s => s.TipoSuscripcion)
                .Include(s => s.IdpuntoAccesoNavigation)
                .Include(s => s.CodigoSuscriptorNavigation)
                .Include(s => s.TrackingSuscripcions)
                .Include(s => s.ImagenSuscripcions)
                .Include(s => s.StrIdsectorNavigation)
                .Where(s => 
                            ((s.CodigoSuscriptorNavigation.StrNombres.Contains(request.Filtro) || 
                            s.CodigoSuscriptorNavigation.StrApellidos.Contains(request.Filtro)) 
                            && (request.TipoFiltro == "1" || request.TipoFiltro == "" || request.TipoFiltro == null))
                            ||
                            ((s.CodigoSuscriptorNavigation.StrNombres.Contains(request.Filtro) || 
                            s.CodigoSuscriptorNavigation.StrCedulaRuc == request.Filtro) 
                            && (request.TipoFiltro == "2"))                            
                        )
                .ToListAsync();
                var suscripcionesDTO = _mapper.Map<List<Suscripcion>, List<SuscripcionDTO>>(suscripcionesList);
                return suscripcionesDTO;
            }
        }

        //POR RANGO GEOGRAFICO
        public class SuscripcionQueryListByCoordinatesRequest: IRequest<List<SuscripcionDTO>>{
            public float Latitud {get; set;}
            public float Longitud {get; set;}
        }

        public class SuscripcionQueryListByCoordinatesHandler: IRequestHandler<SuscripcionQueryListByCoordinatesRequest, List<SuscripcionDTO>> {

            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public SuscripcionQueryListByCoordinatesHandler(InternetControlContext context, IMapper mapper){
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<SuscripcionDTO>> Handle(SuscripcionQueryListByCoordinatesRequest request, CancellationToken cancellationToken){
                var paramLongitud = new SqlParameter("@longitude", request.Longitud);
                var paramLatitud = new SqlParameter("@latitude", request.Latitud);

                var suscripcionesList = await 
                _context.Suscripcions
                .FromSqlRaw("SELECT * FROM getListaSuscripcionesFromUbicacionAndUmbralAsTable(@longitude, @latitude)", paramLongitud, paramLatitud)
                .Include(s => s.TipoSuscripcion)
                .Include(s => s.IdpuntoAccesoNavigation)
                .Include(s => s.CodigoSuscriptorNavigation)
                .Include(s => s.TrackingSuscripcions)
                .Include(s => s.ImagenSuscripcions)
                .Include(s => s.StrIdsectorNavigation)
                .AsNoTracking()
                .ToListAsync();
                var suscripcionesDTO = _mapper.Map<List<Suscripcion>, List<SuscripcionDTO>>(suscripcionesList);
                return suscripcionesDTO;
            }
        }
 
    }
}