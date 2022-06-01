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
    public class SuscripcionController: BaseController
    {
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Unit>> Add(EditHelper.AddSuscriptionRequest request)
        {
            return await Mediator.Send(request);
        } 

        [Route("filter_bydistance_to_position/{latitud}/{longitud}")]
        [HttpGet("{latitud}/{longitud}")]
        public async Task<ActionResult<List<SuscripcionDTO>>> GetByDitanceToPosition(float latitud, float longitud)
        {
            return await Mediator.Send(new ConsultasHelper.SuscripcionQueryListByCoordinatesRequest {Latitud = latitud, Longitud = longitud});
        }


        [ApiExplorerSettings(IgnoreApi=true)]
       [Route("filtrar")]
       [HttpPost]
        public async Task<ActionResult<List<SuscripcionDTO>>> GetByFiltro(ConsultasHelper.SuscripcionQueryListRequest request)
        {
            return await Mediator.Send(request);
        }


        [Route("updateCoordenadas")]
        [HttpPut]
        public async Task<ActionResult<Unit>> Edit(EditHelper.EditCoordenadasSuscripcionRequest request)
        {
            return await Mediator.Send(request);
        }

        [Route("insertImages")]
        [HttpPost]
        public async Task<ActionResult<Unit>> Edit(EditHelper.AddPhotoSuscripcionRequest request)
        {
            return await Mediator.Send(request);
        }

        [Route("updateSuscripcion")]
        [HttpPut]
        public async Task<ActionResult<Unit>> updateSuscripcion(EditHelper.EditSuscripcionRequest request)
        {
            return await Mediator.Send(request);
        }

    }
}