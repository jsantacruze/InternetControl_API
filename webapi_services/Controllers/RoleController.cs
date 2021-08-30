using System.Collections.Generic;
using System.Threading.Tasks;
using business_layer.IdentitySecurity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace webapi_services.Controllers
{
    public class RoleController: BaseController
    {
        [HttpPost("create")]
        public async Task<ActionResult<Unit>> createRole(RoleEditHelper.AddRoleRequest request){
            return await Mediator.Send(request);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Unit>> deleteRole(RoleEditHelper.DeleteRoleRequest request){
            return await Mediator.Send(request);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<IdentityRole>>> Lista(){
            return await Mediator.Send(new RoleQueryHelper.RoleQueryListRequest());
        }

        [HttpGet("list/{username}")]
        public async Task<ActionResult<List<string>>> ObtenerRolesPorUsuario(string username){
            return await Mediator.Send(new RoleQueryHelper.RoleQueryByUserListRequest{Username = username});
        }
    }
}