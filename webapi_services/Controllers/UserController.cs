using System.Threading.Tasks;
using business_layer.DTO;
using business_layer.IdentitySecurity;
using domain_layer.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi_services.Controllers
{
    [AllowAnonymous]
    public class UserController: BaseController
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginHelper.LoginRequest request){
            return await Mediator.Send(request);
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserDTO>> Registrar(UserEditHelper.AddUserRequest request){
            return await Mediator.Send(request);
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>> Editar(UserEditHelper.EditUserRequest request){
            return await Mediator.Send(request);
        }

        [HttpGet("current")]
        public async Task<ActionResult<UserDTO>> getCurrentUser()
        {
            return await Mediator.Send(new LoginHelper.CurrentUserRequest());
        }

        [HttpPost("currentpost")]
        public async Task<ActionResult<UserDTO>> getCurrentUserPost()
        {
            return await Mediator.Send(new LoginHelper.CurrentUserRequest());
        }


        [HttpPost("addrole")]
        public async Task<ActionResult<Unit>> AgregarRoleUsuario(UserEditHelper.AddRoleToUserRequest request){
               return await Mediator.Send(request);
        }
        
        [HttpPost("deleterole")]
        public async Task<ActionResult<Unit>> EliminarRoleUsuario(UserEditHelper.DeleteRoleToUserRequest request){
            return await Mediator.Send(request);
        }
    }
}