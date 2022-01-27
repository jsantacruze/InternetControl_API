using System.Collections.Generic;
using System.Threading.Tasks;
using business_layer.DTO;
using business_layer.IdentitySecurity;
using domain_layer.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using business_layer.Distribucion.Torre;

namespace webapi_services.Controllers
{
    public class TorreDistribucionController: BaseController
    {
       [Route("lista/{ubicacion}")]
       [HttpGet("{ubicacion}")]
        public async Task<ActionResult<List<TorreDistribucionDTO>>> GetByUbicacion(string location_id)
        {
            return await Mediator.Send(new ConsultasHelper.TorreDistribucionQueryListRequest{ubicacion_id=location_id});
        }

    }
}