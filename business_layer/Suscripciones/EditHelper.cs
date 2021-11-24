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
using business_layer.DTO;
using AutoMapper;
using domain_layer.entities;

namespace business_layer.Suscripciones
{
    public class EditHelper
    {
        //ADD SUSCRIPTION
        public class AddSuscriptionRequest: IRequest
        {
            public string StrIdsucursal { get; set; }
            public int StrIdsector { get; set; }
            public double CodigoSuscriptor { get; set; }
            public string StrCedulaUsuarioCreador { get; set; }
            public int EquiposIncluidos { get; set; }
            public int EquiposAdicionales { get; set; }
            public string Observaciones { get; set; }
            public string IdestadoSuscripcion { get; set; }
            public byte[] ImgFotoInstalacion { get; set; }
            public double Latitud { get; set; }
            public double Longitud { get; set; }
            public string DireccionSuscripcion { get; set; }
            public string ReferenciaSuscripcion { get; set; }
            public string Ipv4 { get; set; }
            public string Ipv6 { get; set; }
            public string PasswordCliente { get; set; }
            public int IdequipoCliente { get; set; }
            public int? IdpuntoAcceso { get; set; }
            public int? TipoSuscripcionId { get; set; }
        }

        public class AddSuscriptionValidator: AbstractValidator<AddSuscriptionRequest>{
            public AddSuscriptionValidator(){
                RuleFor(s => s.StrIdsucursal).NotNull().WithMessage("La sucursal es requerida");
                RuleFor(s => s.StrIdsector).NotNull().WithMessage("El sector es requerido");
                RuleFor(s => s.CodigoSuscriptor).NotNull().WithMessage("El suscriptor es requerido");
                RuleFor(s => s.StrCedulaUsuarioCreador).NotNull().WithMessage("El usurio creador es requerido");
                RuleFor(s => s.EquiposIncluidos).NotNull().WithMessage("El número de equipos incliuidos es requerido");
                RuleFor(s => s.EquiposAdicionales).NotNull().WithMessage("El número de equipos adicionales es requerido");
                RuleFor(s => s.IdestadoSuscripcion).NotNull().WithMessage("El estado de la suscripción es requerido");
                RuleFor(s => s.Latitud).NotNull().WithMessage("La latitud es requerida");
                RuleFor(s => s.Longitud).NotNull().WithMessage("El longitud es requerida");
                RuleFor(s => s.DireccionSuscripcion).NotNull().WithMessage("La dirección es requerida");
                RuleFor(s => s.IdequipoCliente).NotNull().WithMessage("El equipo del cliente es requerido");
                RuleFor(s => s.IdpuntoAcceso).NotNull().WithMessage("El punto de acceso es requerido");
                RuleFor(s => s.TipoSuscripcionId).NotNull().WithMessage("El tipo de suscripciómn es requerido");
            }
        }

        public class AddSuscriptionHandler : IRequestHandler<AddSuscriptionRequest>
        {
            private readonly InternetControlContext _context;
            
            private readonly IMapper _mapper;

            public  AddSuscriptionHandler(InternetControlContext context, IMapper mapper){
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(AddSuscriptionRequest request, CancellationToken cancellationToken)
            {
                var nextID = _context.Suscripcions.Max(s => s.DblCodigoSuscripcion) + 1;
                
                var suscripcion = new Suscripcion{
                    DblCodigoSuscripcion =nextID,
                    StrIdsucursal = request.StrIdsucursal,
                    FechaSuscripcion = DateTime.Now,
                    StrIdsector = request.StrIdsector,
                    CodigoSuscriptor = request.CodigoSuscriptor,
                    Activo = false,
                    StrCedulaUsuarioCreador = request.StrCedulaUsuarioCreador,
                    CostoInstalacion = 0,
                    EquiposIncluidos = request.EquiposIncluidos,
                    EquiposAdicionales = request.EquiposAdicionales,
                    ValorMensualEquipos =0, //
                    ValorMensualAdicionales = 0, //
                    Observaciones = request.Observaciones,
                    IdestadoSuscripcion = request.IdestadoSuscripcion,
                    Latitud = request.Latitud,
                    Longitud = request.Longitud,
                    DireccionSuscripcion = request.DireccionSuscripcion,
                    ReferenciaSuscripcion = request.ReferenciaSuscripcion ?? "",
                    Ipv4 = request.Ipv4,
                    Ipv6 = request.Ipv6 ?? "",
                    IdequipoCliente=request.IdequipoCliente,
                    IdpuntoAcceso=request.IdpuntoAcceso,
                    TipoSuscripcionId=request.TipoSuscripcionId,
                    EnviarFactura = false
                };
                _context.Suscripcions.Add(suscripcion);
                
                var result = await _context.SaveChangesAsync();
                 if(result > 0){
                    return Unit.Value;
                 }
                throw new CustomExceptionHelper(HttpStatusCode.NotFound, new {mensaje="No se pudo agregar la suscripción"});
            }
        }
        

        //ADD TRACKING
        public class AddTrackingSuscripcionSuscripcionRequest : IRequest
        {
           public long Idtracking { get; set; }
           public string Evento { get; set; }
           public DateTime FechaRegistro { get; set; }
           public string IdusuarioCrea { get; set; }
           public string IdempleadoAsignado { get; set; }
           public DateTime? FechaAtencion { get; set; }
           public bool Atendido { get; set; }
           public string Observaciones { get; set; }
           public long DblCodigoSuscripcion { get; set; }
           public string StrIdsucursal { get; set; }
           public bool RequiereAtencion { get; set; }

          public virtual EmpleadoDTO IdempleadoAsignadoNavigation { get; set; }
        }
         public class AddTrackingSuscripcionValidator: AbstractValidator<AddTrackingSuscripcionSuscripcionRequest>{
            public  AddTrackingSuscripcionValidator()
            {
                RuleFor(imagen=> imagen.Idtracking).NotNull().WithMessage("Error de PK id Tracking");
                RuleFor(imagen=> imagen.DblCodigoSuscripcion).NotNull().WithMessage("Error null de código suscripción");
                RuleFor(imagen=> imagen.DblCodigoSuscripcion).NotEmpty().WithMessage("Error de código suscripción");
                RuleFor(imagen=> imagen.StrIdsucursal).NotNull().WithMessage("Error null de id sucursal");
                RuleFor(imagen=> imagen.StrIdsucursal).NotEmpty().WithMessage("Error de de id sucursal");
                RuleFor(imagen=> imagen.Evento).NotEmpty().WithMessage("Error  de descripción Evento");
                RuleFor(imagen=> imagen.IdusuarioCrea).NotEmpty().WithMessage("Error de IdusuarioCrea");
                RuleFor(imagen=> imagen.IdempleadoAsignado).NotEmpty().WithMessage("Error de IdusuarioCrea");
                  

            }
        }

        public class  AddTrackingSuscripcionHandler : IRequestHandler<AddTrackingSuscripcionSuscripcionRequest>
        {
            private readonly InternetControlContext _context;
            public  AddTrackingSuscripcionHandler(InternetControlContext context){
                _context = context;
            }
            public async Task<Unit> Handle(AddTrackingSuscripcionSuscripcionRequest request, CancellationToken cancellationToken)
            {
                var tracking = await _context.TrackingSuscripcions.FindAsync(request.Idtracking);
                if(tracking != null)
                {
                    throw new Exception("El tracking no existe");                    
                }
                else
                {
                    tracking = new domain_layer.entities.TrackingSuscripcion();
                    _context.TrackingSuscripcions.Add(tracking);
                }
                tracking.Evento = request.Evento;
                tracking.FechaRegistro = DateTime.Now;
                tracking.IdusuarioCrea = request.IdusuarioCrea;
                tracking.IdempleadoAsignado = request.IdempleadoAsignado;
                tracking.FechaAtencion = request.FechaAtencion;
                tracking.Observaciones = request.Observaciones;
                tracking.RequiereAtencion = request.RequiereAtencion;


                tracking.DblCodigoSuscripcion = request.DblCodigoSuscripcion;
                tracking.StrIdsucursal = request.StrIdsucursal;
                

                var resutl = await _context.SaveChangesAsync();
                if(resutl > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los cambios");
            }
        }
        //ADD PHOTO
        public class AddPhotoSuscripcionRequest : IRequest
        {
           public long ImagenId { get; set; }
            public long DblCodigoSuscripcion { get; set; }
            public string StrIdsucursal { get; set; }
            public string ImagenDescripcion { get; set; }
            public byte[] ImagenValue { get; set; }
            public bool ImagenPrincipal { get; set; }
        }
         public class AddPhotoSuscripcionValidator: AbstractValidator<AddPhotoSuscripcionRequest>{
            public  AddPhotoSuscripcionValidator()
            {
                RuleFor(imagen=> imagen.ImagenId).NotNull().WithMessage("Error de PK código suscripción");
                RuleFor(imagen=> imagen.DblCodigoSuscripcion).NotNull().WithMessage("Error null de código suscripción");
                RuleFor(imagen=> imagen.DblCodigoSuscripcion).NotEmpty().WithMessage("Error de código suscripción");
                RuleFor(imagen=> imagen.StrIdsucursal).NotNull().WithMessage("Error null de id sucursal");
                RuleFor(imagen=> imagen.StrIdsucursal).NotEmpty().WithMessage("Error de de id sucursal");
                RuleFor(imagen=> imagen.ImagenDescripcion).NotEmpty().WithMessage("Error  de descripción Imagen");
                RuleFor(imagen=> imagen.ImagenValue).NotEmpty().WithMessage("Error de byte Imagen");

            }
        }

        public class  AddPhotoSuscripcionHandler : IRequestHandler<AddPhotoSuscripcionRequest>
        {
            private readonly InternetControlContext _context;
            public  AddPhotoSuscripcionHandler(InternetControlContext context){
                _context = context;
            }
            public async Task<Unit> Handle(AddPhotoSuscripcionRequest request, CancellationToken cancellationToken)
            {
                var suscripcion = await _context.ImagenSuscripcions.FindAsync(request.ImagenId);
                if(suscripcion != null)
                {
                    throw new Exception("La suscripcion no existe");                    
                }
                else
                {
                    suscripcion = new domain_layer.entities.ImagenSuscripcion();
                    _context.ImagenSuscripcions.Add(suscripcion);
                }
                suscripcion.ImagenPrincipal = request.ImagenPrincipal;
                suscripcion.ImagenDescripcion = request.ImagenDescripcion;
                suscripcion.ImagenValue = request.ImagenValue;
                suscripcion.DblCodigoSuscripcion = request.DblCodigoSuscripcion;
                suscripcion.StrIdsucursal = request.StrIdsucursal;
                

                var resutl = await _context.SaveChangesAsync();
                if(resutl > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los cambios");
            }
        }

        //EDIT SUSCRIPTION
        public class EditSuscripcionRequest: IRequest
        {
            public long DblCodigoSuscripcion { get; set; }
            public DateTime FechaSuscripcion { get; set; }
            public string StrIdsucursal { get; set; }
            public int StrIdsector { get; set; }
            public double CodigoSuscriptor { get; set; }
            public bool Activo { get; set; }
            public string StrCedulaUsuarioCreador { get; set; }
            public double CostoInstalacion { get; set; }
            public int EquiposIncluidos { get; set; }
            public int EquiposAdicionales { get; set; }
            public double ValorMensualEquipos { get; set; }
            public double ValorMensualAdicionales { get; set; }
            public string Observaciones { get; set; }
            public string IdestadoSuscripcion { get; set; }
            public byte[] ImgFotoInstalacion { get; set; }
            public double Latitud { get; set; }
            public double Longitud { get; set; }
            public string DireccionSuscripcion { get; set; }
            public string ReferenciaSuscripcion { get; set; }
            public string Ipv4 { get; set; }
            public string Ipv6 { get; set; }
            public string PasswordCliente { get; set; }
            public short? NumMesesForSuspension { get; set; }
            public string Urlconsumo { get; set; }
            public int IdequipoCliente { get; set; }
            public int? IdpuntoAcceso { get; set; }
            public bool EnviarFactura { get; set; }
            public int? TipoSuscripcionId { get; set; }

        }
        public class EditSuscripcionValidator: AbstractValidator<EditSuscripcionRequest>{
            public  EditSuscripcionValidator()
            {
                
                RuleFor(suscripcion => suscripcion.DblCodigoSuscripcion).NotEmpty().WithMessage("Error de PK código suscripción");
                RuleFor(suscripcion => suscripcion.StrIdsucursal).NotEmpty().WithMessage("Error de PK id sucursal");
                RuleFor(suscripcion => suscripcion.FechaSuscripcion).NotEmpty().WithMessage("El valor de FechaSuscripcion es requerido");
              
                RuleFor(suscripcion => suscripcion.StrIdsector).NotEmpty().WithMessage("El valor de StrIdsector es requerido");
                RuleFor(suscripcion => suscripcion.CodigoSuscriptor).NotEmpty().WithMessage("El valor de CodigoSuscriptor es requerido");
                //RuleFor(suscripcion => suscripcion.Activo).NotEmpty().WithMessage("El valor de Activo es requerido");
                RuleFor(suscripcion => suscripcion.CostoInstalacion).NotEmpty().WithMessage("El valor de Costo Instalación es requerido");
                RuleFor(suscripcion => suscripcion.EquiposIncluidos).NotEmpty().WithMessage("El valor de Equipos Incluidos es requerido");
                RuleFor(suscripcion => suscripcion.EquiposAdicionales).NotNull().WithMessage("El valor de Equipos Adicionales es requerido");
                RuleFor(suscripcion => suscripcion.ValorMensualEquipos).NotEmpty().WithMessage("El valor de Valor Mensual Equipos es requerido");
                RuleFor(suscripcion => suscripcion.ValorMensualAdicionales).NotEmpty().WithMessage("El Valor Mensual Adicionales es requerido");
                RuleFor(suscripcion => suscripcion.IdestadoSuscripcion).NotEmpty().WithMessage("El Valor Idestado Suscripcion es requerido");
                RuleFor(suscripcion => suscripcion.Latitud).NotNull().WithMessage("El valor de Latitud es requerido");
                RuleFor(suscripcion => suscripcion.Longitud).NotNull().WithMessage("El valor de Longitud es requerido");
                RuleFor(suscripcion => suscripcion.DireccionSuscripcion).NotEmpty().WithMessage("El Valor Dirección es requerido");
                RuleFor(suscripcion => suscripcion.IdequipoCliente).NotEmpty().WithMessage("El Valor IdequipoCliente es requerido");
                RuleFor(suscripcion => suscripcion.EnviarFactura).NotNull().WithMessage("El Valor EnviarFactura es requerido");

            }
        }

        public class EditSuscripcionHandler : IRequestHandler<EditSuscripcionRequest>
        {
            private readonly InternetControlContext _context;
            public EditSuscripcionHandler(InternetControlContext context){
                _context = context;
            }
            public async Task<Unit> Handle(EditSuscripcionRequest request, CancellationToken cancellationToken)
            {
                var suscripcion = await _context.Suscripcions.FindAsync(request.DblCodigoSuscripcion, request.StrIdsucursal);
                if(suscripcion == null)
                {
                    throw new Exception("La suscripcion no existe");                    
                }

                suscripcion.StrIdsector = request.StrIdsector;
                suscripcion.StrIdsucursal = request.StrIdsucursal;
                suscripcion.CodigoSuscriptor = request.CodigoSuscriptor;
                suscripcion.Activo = request.Activo;
                suscripcion.CostoInstalacion = suscripcion.CostoInstalacion;
                suscripcion.EquiposIncluidos = request.EquiposIncluidos;
                suscripcion.EquiposAdicionales = request.EquiposAdicionales;
                suscripcion.ValorMensualAdicionales = request.ValorMensualAdicionales;
                suscripcion.Observaciones = request.Observaciones;
                suscripcion.IdestadoSuscripcion = request.IdestadoSuscripcion;
                suscripcion.ImgFotoInstalacion = request.ImgFotoInstalacion;
                suscripcion.Latitud = request.Latitud !=0 ? request.Latitud : suscripcion.Latitud;
                suscripcion.Longitud = request.Longitud !=0 ? request.Longitud :  suscripcion.Longitud;
                suscripcion.DireccionSuscripcion = request.DireccionSuscripcion;
                suscripcion.ReferenciaSuscripcion = request.ReferenciaSuscripcion;
                suscripcion.Ipv4 = request.Ipv4;
                suscripcion.Ipv6 = request.Ipv6;
                suscripcion.PasswordCliente = request.PasswordCliente;
                suscripcion.IdequipoCliente = request.IdequipoCliente;
                suscripcion.IdpuntoAcceso = request.IdpuntoAcceso;
                suscripcion.TipoSuscripcionId = request.TipoSuscripcionId;
                
                var resutl = await _context.SaveChangesAsync();
                if(resutl > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los cambios");
            }
        }

        //EDIT COORDENADAS
        public class EditCoordenadasSuscripcionRequest: IRequest{
            public long DblCodigoSuscripcion { get; set; }
            public string StrIdsucursal { get; set; }
            public double Latitud { get; set; }
            public double Longitud { get; set; }
        }
        public class EditCoordenadasSuscripcionValidator: AbstractValidator<EditCoordenadasSuscripcionRequest>{
            public  EditCoordenadasSuscripcionValidator()
            {
                //RuleFor(suscripcion => suscripcion.DblCodigoSuscripcion).Null().WithMessage("Error de PK código suscripción");
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