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
namespace business_layer.Nomencladores
{
    public class ConsultasNomencladoresHelpers
    {
        public class CiudadQueryListRequest : IRequest<List<CiudadDTO>>
        {

        }
        public class CiudadQueryListHandler : IRequestHandler<CiudadQueryListRequest, List<CiudadDTO>>
        {
            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;
            public CiudadQueryListHandler(InternetControlContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }
            public async Task<List<CiudadDTO>> Handle(CiudadQueryListRequest request, CancellationToken cancellationToken)
            {
                var result = await
                _context.Ciudads
                //.Include(s => s.StrIdciudadNavigation)
                //.Include(s => s.StrIdsexoNavigation)
                //.Where(s => s.BlnActivo)
                .ToListAsync();
                var ciudadDTO = _mapper.Map<List<Ciudad>, List<CiudadDTO>>(result);
                return ciudadDTO;
            }
        }

        //SEXO
        public class SexoQueryListRequest : IRequest<List<SexoDTO>>
        {

        }
        public class SexoQueryListHandler : IRequestHandler<SexoQueryListRequest, List<SexoDTO>>
        {
            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;
            public SexoQueryListHandler(InternetControlContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }
            public async Task<List<SexoDTO>> Handle(SexoQueryListRequest request, CancellationToken cancellationToken)
            {
                var result = await
                _context.Sexos
                .ToListAsync();
                var SexoDTO = _mapper.Map<List<Sexo>, List<SexoDTO>>(result);
                return SexoDTO;
            }
        }
    }
}