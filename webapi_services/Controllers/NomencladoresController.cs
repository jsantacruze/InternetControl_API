using System.Collections.Generic;
using System.Threading.Tasks;
using business_layer.DTO;
using business_layer.IdentitySecurity;
using domain_layer.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using business_layer.Nomencladores;
namespace webapi_services.Controllers
{
    public class NomencladoresController : BaseController
    {
        [HttpGet("getCiudades")]
        public async Task<ActionResult<List<CiudadDTO>>> GetCiudades()
        {
            return await Mediator.Send(new ConsultasNomencladoresHelpers.CiudadQueryListRequest());
        }
        [HttpGet("getSexos")]
        public async Task<ActionResult<List<SexoDTO>>> GetSexos()
        {
            return await Mediator.Send(new ConsultasNomencladoresHelpers.SexoQueryListRequest());
        }
    }
}