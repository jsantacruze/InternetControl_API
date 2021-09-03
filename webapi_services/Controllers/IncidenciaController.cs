using System.Collections.Generic;
using System.Threading.Tasks;
using business_layer.DTO;
using business_layer.Incidencias;
using Microsoft.AspNetCore.Mvc;

namespace webapi_services.Controllers
{
    public class IncidenciaController: BaseController
    {
        [HttpGet("list")]
        public async Task<ActionResult<List<IncidenciaDTO>>> GetAll(ConsultasHelper.IncidenciaQueryListRequest request)
        {
            return await Mediator.Send(request);
        }

    }
}