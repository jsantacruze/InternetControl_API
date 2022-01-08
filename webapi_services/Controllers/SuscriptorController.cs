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
    public class SuscriptorController : BaseController
    {
        [Route("filtrar/{filtro}")]
        [HttpGet("{filtro}")]
        public async Task<ActionResult<List<SuscriptorDTO>>> GetByFiltro(string filtro)
        {
            return await Mediator.Send(new ConsultasHelper.SuscriptorListByFilterRequest { Filtro = filtro });
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<SuscriptorDTO>>> GetAll()
        {
            return await Mediator.Send(new ConsultasHelper.SuscriptorQueryListRequest());
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Unit>> Add(EditHelper.AddSuscriptorRequest request)
        {
            return await Mediator.Send(request);
        }
        [Route("update")]
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(EditHelper.EditSuscriptorRequest request)
        {
            return await Mediator.Send(request);
        }
        [Route("delete")]
        [HttpPut]
        public async Task<ActionResult<Unit>> Update(EditHelper.DeleteSuscriptorRequest request)
        {
            return await Mediator.Send(request);
        }
    }
}