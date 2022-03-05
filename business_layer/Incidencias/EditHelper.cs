using System;
using System.Linq;
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
        //ATENDER INCIDENCIAS
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

        //REGISTRAR IMAGENES INCIDENCIAS
            public class RegistrarImagenIncidenciaRequest: IRequest{
                public byte[] imagen_value { get; set; }
                public string imagen_descripcion { get; set; }
                public long incidencia_id { get; set; }
            }
            public class RegistrarImagenIncidenciaValidator: AbstractValidator<RegistrarImagenIncidenciaRequest>{
            public RegistrarImagenIncidenciaValidator()
            {
                RuleFor(v => v.incidencia_id).NotEmpty().WithMessage("Debe especificar el identificador de la incidencia");
                RuleFor(v => v.imagen_value).NotNull().WithMessage("Debe proporcionar una imagen");
            }

            public class RegistrarImagenIncidenciaHandler : IRequestHandler<RegistrarImagenIncidenciaRequest>
            {
                private readonly InternetControlContext _context;
                public RegistrarImagenIncidenciaHandler(InternetControlContext context){
                    _context = context;
                }
                public async Task<Unit> Handle(RegistrarImagenIncidenciaRequest request, CancellationToken cancellationToken)
                {
                    var nextID = _context.TrackinSuscripcionImages.Max(s => s.ImageId) + 1;

                    var imagen_incidencia = new domain_layer.entities.TrackinSuscripcionImage()
                    {
                        ImageId=nextID,
                        ImageTrackingId = request.incidencia_id,
                        ImageValue = request.imagen_value,
                        ImageDescription = request.imagen_descripcion
                    };

                    _context.TrackinSuscripcionImages.Add(imagen_incidencia);
                    var result = await _context.SaveChangesAsync();
                    if(result > 0)
                    {
                        return Unit.Value;
                    }
                    throw new CustomExceptionHelper(HttpStatusCode.InternalServerError, new {mensaje="No se guardaron los cambios"});
                }
            }
        }
        //ELIMINAR IMAGENES INCIDENCIAS
            public class EliminarImagenIncidenciaRequest: IRequest{
                public long imagen_id { get; set; }
            }
            public class EliminarImagenIncidenciaValidator: AbstractValidator<EliminarImagenIncidenciaRequest>{
            public EliminarImagenIncidenciaValidator()
            {
                RuleFor(v => v.imagen_id).NotNull().WithMessage("Debe especificar el identificador de la imagen a eliminar");
            }

            public class EliminarImagenIncidenciaHandler : IRequestHandler<EliminarImagenIncidenciaRequest>
            {
                private readonly InternetControlContext _context;
                public EliminarImagenIncidenciaHandler(InternetControlContext context){
                    _context = context;
                }
                public async Task<Unit> Handle(EliminarImagenIncidenciaRequest request, CancellationToken cancellationToken)
                {
                    var imagen = await _context.TrackinSuscripcionImages.FindAsync(request.imagen_id);
                    if (imagen == null)
                    {
                        throw new CustomExceptionHelper(HttpStatusCode.NotFound, new {mensaje="La imagen no se encuentra registrada"});
                    }
                    
                    _context.TrackinSuscripcionImages.Remove(imagen);
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