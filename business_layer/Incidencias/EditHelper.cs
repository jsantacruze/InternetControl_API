using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using business_layer.ExceptionManager;
using data_access;
using FluentValidation;
using MediatR;

namespace business_layer.Incidencias
{
    public class EditHelper
    {
            public class AtenderIncidenciaRequest: IRequest{
                public long incidencia_id { get; set; }
                public bool incidencia_atendida { get; set; }
                public string incidencia_observaciones { get; set; }
            }
            public class AtenderIncidenciaValidator: AbstractValidator<AtenderIncidenciaRequest>{
            public AtenderIncidenciaValidator()
            {
                RuleFor(v => v.incidencia_id).NotEmpty().WithMessage("Debe especificar el identificador de la incidencia");
            }

            public class AtenderIncidenciaHandler : IRequestHandler<AtenderIncidenciaRequest>
            {
                private readonly InternetControlContext _context;
                public AtenderIncidenciaHandler(InternetControlContext context){
                    _context = context;
                }
                public async Task<Unit> Handle(AtenderIncidenciaRequest request, CancellationToken cancellationToken)
                {
                    var incidencia = await _context.TrackingSuscripcions.FindAsync(request.incidencia_id);
                    if(incidencia == null)
                    {
                        throw new CustomExceptionHelper(HttpStatusCode.NotFound, new {mensaje="La inicidencia no existe"});                    
                    }   
                    incidencia.Atendido = request.incidencia_atendida;
                    incidencia.FechaAtencion = DateTime.Now;
                    incidencia.Observaciones = request.incidencia_observaciones ?? incidencia.Observaciones;

                    var result = await _context.SaveChangesAsync();
                    if(result > 0)
                    {
                        return Unit.Value;
                    }
                    throw new CustomExceptionHelper(HttpStatusCode.InternalServerError, new {mensaje="No se guardaron los cambios"});
                }
            }
        }

    }
}