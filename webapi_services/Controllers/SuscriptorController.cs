using System.Collections.Generic;
using System.Threading.Tasks;
using business_layer.DTO;
using business_layer.IdentitySecurity;
using domain_layer.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using business_layer.Suscriptores;

namespace webapi_services.Controllers
{
    public class SuscriptorController: BaseController
    {
       [Route("filtrar/{filtro}")]
       [HttpGet("{filtro}")]
        public async Task<ActionResult<List<SuscriptorDTO>>> GetByFiltro(string filtro)
        {
            return await Mediator.Send(new ConsultasHelper.SuscriptorQueryListRequest{Filtro=filtro});
        }
        

    }
}