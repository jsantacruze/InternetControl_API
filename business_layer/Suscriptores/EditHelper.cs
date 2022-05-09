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

namespace business_layer.Suscriptores
{
    public class EditHelper
    {
        //ADD SUSCRIPTOR
        public class AddSuscriptorRequest: IRequest
        {
            public string StrCedulaRuc { get; set; }
            public string StrNombres { get; set; }
            public string StrApellidos { get; set; }
            public string StrRazonSocial { get; set; }
            public string StrIdciudad { get; set; }
            public string StrDireccion { get; set; }
            public string StrIdsexo { get; set; }
            public string StrTelefono { get; set; }
            public string StrMovil { get; set; }
            public string StrEmail { get; set; }

            public byte[] ImgFoto { get; set; }

            public bool BlnPersonaNatural { get; set; }
            public double DblPorcentajeDescuento { get; set; }
            public string StrObservaciones { get; set; }
        }
        public class AddSuscriptorValidator : AbstractValidator<AddSuscriptorRequest>
        {
            public AddSuscriptorValidator()
            {
                RuleFor(s => s.StrCedulaRuc).NotEmpty().WithMessage("El numero de Cedula es requerido");
                RuleFor(s => s.StrNombres).NotEmpty().WithMessage("El campo Nombres es requerido");
                RuleFor(s => s.StrApellidos).NotEmpty().WithMessage("El campo Apellidos es requerido");
                //RuleFor(s => s.StrRazonSocial).NotEmpty().WithMessage("El campo razón social es requerido");
                RuleFor(s => s.StrIdciudad).NotEmpty().WithMessage("El campo ciudad es requerido");
                RuleFor(s => s.StrDireccion).NotEmpty().WithMessage("El campo Dirección es requerido");
                RuleFor(s => s.StrIdsexo).NotEmpty().WithMessage("El campo Sexo es requerido");
                RuleFor(s => s.StrMovil).NotEmpty().WithMessage("El campo Movil es requerido");
                RuleFor(s => s.StrEmail).NotEmpty().WithMessage("El campo Email es requerido");

            }
        }

        public class AddSuscriptorHandler : IRequestHandler<AddSuscriptorRequest>
        {
            private readonly InternetControlContext _context;

            private readonly IMapper _mapper;

            public AddSuscriptorHandler(InternetControlContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(AddSuscriptorRequest request, CancellationToken cancellationToken)
            {
                var suscriptor =  _context.Suscriptors.FirstOrDefault(s =>s.StrCedulaRuc.Equals(request.StrCedulaRuc));
                if (suscriptor != null)
                {
                    throw new Exception("El suscriptor ya se encuentra registrado");
                }
                var nextID = _context.Suscriptors.Max(s => s.DblCodigoSuscriptor) + 1;

                suscriptor = new Suscriptor
                {
                    DblCodigoSuscriptor = nextID,
                    StrCedulaRuc=request.StrCedulaRuc,
                    StrNombres = request.StrNombres,
                    StrApellidos = request.StrApellidos,
                    StrRazonSocial = request.StrRazonSocial,
                    StrIdciudad = request.StrIdciudad,
                    StrDireccion = request.StrDireccion,
                    StrIdsexo = request.StrIdsexo,
                    StrTelefono = request.StrTelefono,
                    StrMovil = request.StrMovil,
                    StrEmail = request.StrEmail,
                    ImgFoto = request.ImgFoto,
                    BlnActivo = true,
                    BlnPersonaNatural = request.BlnPersonaNatural,
                    DblPorcentajeDescuento = request.DblPorcentajeDescuento,
                    StrObservaciones=request.StrObservaciones,
                };
                _context.Suscriptors.Add(suscriptor);

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo agregar el suscriptor");
            }
        }
        //EDITAR
        public class EditSuscriptorRequest : IRequest
        {
            public double DblCodigoSuscriptor { get; set; }
            public string StrCedulaRuc { get; set; }
            public string StrNombres { get; set; }
            public string StrApellidos { get; set; }
            public string StrRazonSocial { get; set; }
            public string StrIdciudad { get; set; }
            public string StrDireccion { get; set; }
            public string StrIdsexo { get; set; }
            public string StrTelefono { get; set; }
            public string StrMovil { get; set; }
            public string StrEmail { get; set; }

            public byte[] ImgFoto { get; set; }
            //public bool BlnActivo { get; set; }

            public bool BlnPersonaNatural { get; set; }
            public double DblPorcentajeDescuento { get; set; }
            public string StrObservaciones { get; set; }
        }
        public class EditSuscriptorValidator : AbstractValidator<EditSuscriptorRequest>
        {
            public EditSuscriptorValidator()
            {
                RuleFor(s => s.StrCedulaRuc).NotEmpty().WithMessage("El numero de Cedula es requerido");
                RuleFor(s => s.StrNombres).NotEmpty().WithMessage("El campo Nombres es requerido");
                RuleFor(s => s.StrApellidos).NotEmpty().WithMessage("El campo Apellidos es requerido");
                //RuleFor(s => s.StrRazonSocial).NotEmpty().WithMessage("El campo razón social es requerido");
                RuleFor(s => s.StrIdciudad).NotEmpty().WithMessage("El campo ciudad es requerido");
                RuleFor(s => s.StrDireccion).NotEmpty().WithMessage("El campo Dirección es requerido");
                RuleFor(s => s.StrIdsexo).NotEmpty().WithMessage("El campo Sexo es requerido");
                RuleFor(s => s.StrMovil).NotEmpty().WithMessage("El campo Movil es requerido");
                RuleFor(s => s.StrEmail).NotEmpty().WithMessage("El campo Email es requerido");

            }
        }
        public class EditSuscripcionHandler : IRequestHandler<EditSuscriptorRequest>
        {
            private readonly InternetControlContext _context;
            public EditSuscripcionHandler(InternetControlContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EditSuscriptorRequest request, CancellationToken cancellationToken)
            {
                var suscriptor = await _context.Suscriptors.FindAsync(request.DblCodigoSuscriptor);
                if (suscriptor == null)
                {
                    throw new Exception("El suscriptor no se encuentra registrado");
                }

                suscriptor.StrNombres = request.StrNombres;
                suscriptor.StrApellidos = request.StrApellidos;
                suscriptor.StrRazonSocial = request.StrRazonSocial;
                suscriptor.StrIdciudad = request.StrIdciudad;
                suscriptor.StrDireccion = request.StrDireccion;
                suscriptor.StrIdsexo = request.StrIdsexo;
                suscriptor.StrTelefono = request.StrTelefono;
                suscriptor.StrMovil = request.StrMovil;
                suscriptor.StrEmail = request.StrEmail;
                suscriptor.ImgFoto = request.ImgFoto;
                suscriptor.BlnPersonaNatural = request.BlnPersonaNatural;
                suscriptor.DblPorcentajeDescuento = request.DblPorcentajeDescuento;
                suscriptor.StrObservaciones = request.StrObservaciones;

                var resutl = await _context.SaveChangesAsync();
                if (resutl > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los cambios");
            }
        }

        public class DeleteSuscriptorRequest : IRequest
        {
            public double DblCodigoSuscriptor { get; set; }
        }
        public class DeleteSuscriptorValidator : AbstractValidator<DeleteSuscriptorRequest>
        {
            public DeleteSuscriptorValidator()
            {
                RuleFor(s => s.DblCodigoSuscriptor).NotEmpty().WithMessage("El codigo del suscriptor es requerido");
            }
        }
        public class DeleteSuscripcionHandler : IRequestHandler<DeleteSuscriptorRequest>
        {
            private readonly InternetControlContext _context;
            public DeleteSuscripcionHandler(InternetControlContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteSuscriptorRequest request, CancellationToken cancellationToken)
            {
                var suscriptor = await _context.Suscriptors.FindAsync(request.DblCodigoSuscriptor);
                if (suscriptor == null)
                {
                    throw new Exception("El suscriptor no se encuentra registrado");
                }

                suscriptor.BlnActivo = false;

                var resutl = await _context.SaveChangesAsync();
                if (resutl > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los cambios");
            }
        }
    }

}