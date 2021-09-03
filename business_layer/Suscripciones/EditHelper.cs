using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using data_access;
using domain_layer;
using FluentValidation;
using MediatR;
using business_layer.ExceptionManager;
using System.Net;
namespace business_layer.Suscripciones
{
    public class EditHelper
    {
         public class EditCoordenadasSuscripcionRequest: IRequest{
            public long DblCodigoSuscripcion { get; set; }
            public string StrIdsucursal { get; set; }
            public double Latitud { get; set; }
            public double Longitud { get; set; }
        }
        public class EditCoordenadasSuscripcionValidator: AbstractValidator<EditCoordenadasSuscripcionRequest>{
            public  EditCoordenadasSuscripcionValidator()
            {
                RuleFor(suscripcion => suscripcion.DblCodigoSuscripcion).Null().WithMessage("Error de PK código suscripción");
                RuleFor(suscripcion => suscripcion.DblCodigoSuscripcion).NotEmpty().WithMessage("Error de PK código suscripción");
                RuleFor(suscripcion => suscripcion.StrIdsucursal).NotEmpty().WithMessage("Error de PK id sucursal");
                RuleFor(suscripcion => suscripcion.Latitud).NotEmpty().WithMessage("El valor de Latitud es requerido");
                RuleFor(suscripcion => suscripcion.Longitud).NotEmpty().WithMessage("El valor de Longitud es requerido");
            }
        }

        public class EditCoordenadasSuscripcionHandler : IRequestHandler<EditCoordenadasSuscripcionRequest>
        {
            private readonly InternetControlContext _context;
            public EditCoordenadasSuscripcionHandler(InternetControlContext context){
                _context = context;
            }
            public async Task<Unit> Handle(EditCoordenadasSuscripcionRequest request, CancellationToken cancellationToken)
            {
                var suscripcion = await _context.Suscripcions.FindAsync(request.DblCodigoSuscripcion, request.StrIdsucursal);
                if(suscripcion == null)
                {
                    throw new Exception("La suscripcion no existe");                    
                }
                if (request.Latitud == 0)
                {
                    throw new Exception("El valor Latitud no puede ser cero");
                }
                if(request.Longitud == 0)
                {
                    throw new Exception("El valor Longitud no puede ser cero");
                }
                suscripcion.Latitud = request.Latitud !=0 ? request.Latitud : suscripcion.Latitud;
                suscripcion.Longitud = request.Longitud !=0 ? request.Longitud :  suscripcion.Longitud;

                var resutl = await _context.SaveChangesAsync();
                if(resutl > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los cambios");
            }
        }
    }
}