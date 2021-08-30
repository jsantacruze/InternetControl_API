using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using business_layer.ExceptionManager;
using data_access;
using domain_layer.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace business_layer.IdentitySecurity
{
    public class RoleQueryHelper
    {
        public class RoleQueryListRequest : IRequest<List<IdentityRole>> {
        }

        public class RoleQueryListHandler : IRequestHandler<RoleQueryListRequest, List<IdentityRole>> {
            
            private readonly InternetControlContext _context;
            public RoleQueryListHandler(InternetControlContext context){
                _context = context;
            }

            public async Task<List<IdentityRole>> Handle(RoleQueryListRequest request, CancellationToken cancellationToken)
            {
                var roles =  await _context.Roles.ToListAsync();
                return roles;            }
        }

        //OBTENER ROLES POR USUARIO
         public class RoleQueryByUserListRequest : IRequest<List<string>> {
            public string Username {get;set;}
        }

        public class RoleQueryByUserListHandler : IRequestHandler<RoleQueryByUserListRequest, List<string>>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            
            public RoleQueryByUserListHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager){
                _roleManager = roleManager;
                _userManager = userManager;
            }

            public async Task<List<string>> Handle(RoleQueryByUserListRequest request, CancellationToken cancellationToken)
            {
                var usuarioIden = await _userManager.FindByNameAsync(request.Username);
                if(usuarioIden == null){
                    throw new CustomExceptionHelper(HttpStatusCode.NotFound, new {mensaje = "No existe el usuario"});
                }

                var resultados = await _userManager.GetRolesAsync(usuarioIden);
                return  new List<string>(resultados);
            }
        }
        
 
    }
}