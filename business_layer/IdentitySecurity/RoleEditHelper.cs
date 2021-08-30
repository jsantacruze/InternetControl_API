using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using business_layer.ExceptionManager;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace business_layer.IdentitySecurity
{
    public class RoleEditHelper
    {
        public class AddRoleRequest : IRequest{
            public string Nombre {get; set;}   
        }

        public class AddRoleValidator : AbstractValidator<AddRoleRequest>{
            public AddRoleValidator(){
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }

        public class AddRoleHandler : IRequestHandler<AddRoleRequest>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            public AddRoleHandler(RoleManager<IdentityRole> roleManager){
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle(AddRoleRequest request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(request.Nombre);
                if(role != null){
                    throw new CustomExceptionHelper(HttpStatusCode.BadRequest, new {mensaje="El rol ya existe"});
                }

                var result = await _roleManager.CreateAsync(new IdentityRole(request.Nombre));
                if(result.Succeeded){
                    return Unit.Value;
                }

                throw new Exception("No se pudo guarar el rol");
            }
        }


        public class DeleteRoleRequest : IRequest{
            public string Nombre {get;set;}
        }

        public class DeleteRoleValidator : AbstractValidator<DeleteRoleRequest>{
            public DeleteRoleValidator(){
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }

        public class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest>
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            public DeleteRoleHandler(RoleManager<IdentityRole> roleManager){
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(request.Nombre);
                if(role == null){
                    throw new CustomExceptionHelper(HttpStatusCode.NotFound, new {mensaje="No existe el rol"});
                }

                var resultado = await _roleManager.DeleteAsync(role);
                if(resultado.Succeeded){
                    return Unit.Value;
                }

                throw new System.Exception("No se pudo eliminar el rol");
            }
        }
    
    }
}