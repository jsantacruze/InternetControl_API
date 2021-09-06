using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using business_layer.DTO;
using data_access;
using domain_layer.entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace business_layer.Incidencias
{
    public class ConsultasHelper
    {
        public class IncidenciaQueryListRequest : IRequest<List<IncidenciaDTO>>
        {
            //1> FECHA REGISTRO, 3>FECHA ATENCION
            public int opcionBusqueda{get; set;}
           public DateTime fechaIni {get; set;}
           public DateTime fechaFin  {get; set;}
           
           public String cedula_emp_asignado  {get; set;}
           public bool estado_atendido {get; set;}
        }

        public class IncidenciaQueryListValidator: AbstractValidator<IncidenciaQueryListRequest>{
            public  IncidenciaQueryListValidator()
            {
                RuleFor(v => v.opcionBusqueda).NotEmpty().WithMessage("Debe especificar una opción para las fechas de búsqueda. 1: F. Regisro. | 2: F. Atención");
                RuleFor(v => v.fechaIni).NotEmpty().WithMessage("Se requiere una fecha inicial");
                RuleFor(v => v.fechaFin).NotEmpty().WithMessage("Se requiere una fecha final");
            }
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
                .Include(s => s.Suscripcion)
                .Include(s => s.IdempleadoAsignadoNavigation)
                .Include(s=> s.IdusuarioCreaNavigation)
                .ThenInclude(u => u.CedulaEmpleadoNavigation)
                .Where(t => t.Atendido == request.estado_atendido
                    && 
                   ( 
                        (t.FechaRegistro >= request.fechaIni && t.FechaRegistro <= request.fechaFin && request.opcionBusqueda == 1) ||
                        (t.FechaAtencion >= request.fechaIni && t.FechaAtencion <= request.fechaFin && request.opcionBusqueda == 2 && t.Atendido)  
                    )
                    && t.RequiereAtencion
                    && 
                        (
                            (t.IdempleadoAsignado == request.cedula_emp_asignado && request.cedula_emp_asignado != null) ||
                            (request.cedula_emp_asignado == null)
                        )
                )
                .ToListAsync();
                var incidenciasDTO = _mapper.Map<List<TrackingSuscripcion>, List<IncidenciaDTO>>(result);
                return incidenciasDTO;
            }
        }
        
        //NUMERO DE INICIDENCIAS POR USUARIO
        public class IncidenciasPendientesRequest : IRequest<int>
        {
            public string cedula_usuario {get; set;}
            public bool estado_atendido {get; set;}
        }

        public class IncidenciasPendientesHabnler : IRequestHandler<IncidenciasPendientesRequest, int>
        {
            private readonly InternetControlContext _context;

            public IncidenciasPendientesHabnler(InternetControlContext context)
            {
                this._context = context;
            }

            public async Task<int> Handle(IncidenciasPendientesRequest request, CancellationToken cancellationToken)
            {
                var result = await
                    this._context.TrackingSuscripcions
                    .Where(t => t.Atendido == request.estado_atendido && t.IdempleadoAsignado == request.cedula_usuario).ToListAsync();
                return result.Count();
            }
        }


    }
}