using System.Collections.Generic;
using System.Threading.Tasks;
using business_layer.DTO;
using business_layer.IdentitySecurity;
using domain_layer.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using business_layer.Suscripciones;

namespace webapi_services.Controllers
{
    public class EstadoSuscripcionController: BaseController
    {
       [HttpGet]
        public async Task<ActionResult<List<EstadoSuscripcionDTO>>> Get()
        {
            return await Mediator.Send(new ConsultasNomencladoresHelper.EstadoSuscripcionQueryListRequest());
        }   
   
    }
}