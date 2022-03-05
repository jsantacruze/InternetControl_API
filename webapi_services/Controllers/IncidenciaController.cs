using System.Collections.Generic;
using System.Threading.Tasks;
using business_layer.DTO;
using business_layer.Incidencias;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace webapi_services.Controllers
{
    public class IncidenciaController: BaseController
    {
        
        [HttpPost("list")]
        public async Task<ActionResult<List<IncidenciaDTO>>> GetAll(ConsultasHelper.IncidenciaQueryListRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut("add_image")]
        public async Task<ActionResult<Unit>> AddImage(EditHelper.RegistrarImagenIncidenciaRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPut("attend")]
        public async Task<ActionResult<Unit>> Edit(EditHelper.AtenderIncidenciaRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost("pendientes_empleado")]
        public async Task<int> GetPendientesByEmpleado(ConsultasHelper.IncidenciasPendientesRequest request)
        {
            return await Mediator.Send(request);
        }

    }
}