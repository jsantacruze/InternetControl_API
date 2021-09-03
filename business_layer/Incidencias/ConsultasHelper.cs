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

namespace business_layer.Incidencias
{
    public class ConsultasHelper
    {
        public class IncidenciaQueryListRequest : IRequest<List<IncidenciaDTO>>
        {
           public DateTime? fechaRegistro {get; set;}
           public DateTime? fechaAsignacion  {get; set;}

           public DateTime? fechaAtencion  {get; set;}
           public String user_id_asignado  {get; set;}
           public bool? estado_atendido {get; set;}
        }
        public class IncidenciaQueryListHandler : IRequestHandler<IncidenciaQueryListRequest, List<IncidenciaDTO>>
        {
            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public IncidenciaQueryListHandler(InternetControlContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<List<IncidenciaDTO>> Handle(IncidenciaQueryListRequest request, CancellationToken cancellationToken)
            {
                var result = await
                _context.TrackingSuscripcions
                //.Include(s => s.IdempleadoAsignadoNavigation)
                //.Include(s=> s.IdusuarioCreaNavigation)
                //.ThenInclude(u => u.CedulaEmpleadoNavigation)
                .ToListAsync();
                var incidenciasDTO = _mapper.Map<List<TrackingSuscripcion>, List<IncidenciaDTO>>(result);
                return incidenciasDTO;
            }
        }

    }
}