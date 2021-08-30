using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using business_layer.DTO;
using business_layer.ExceptionManager;
using business_layer.IdentitySecurity.Contracts;
using data_access;
using domain_layer.Security;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace business_layer.IdentitySecurity
{
    public class UserEditHelper
    {
        public class AddUserRequest : IRequest<UserDTO>{
            public string Nombres{get; set;}
            public string Apellidos{get; set;}
            public string Email{get; set;}
            public string Password{get; set;}
            public string UserName{get; set;}
        }
         public class AddUserValidator: AbstractValidator<AddUserRequest>{
            public  AddUserValidator()
            {
                RuleFor(u => u.Nombres).NotEmpty().WithMessage("El campo Nombres es requerido");
                RuleFor(u => u.Apellidos).NotEmpty().WithMessage("El campo Apellidos es requerido");
                RuleFor(u => u.Email).NotEmpty().WithMessage("El campo Email es requerido");
                RuleFor(u => u.Password).NotEmpty().WithMessage("El campo Password es requerido");
                RuleFor(u => u.UserName).NotEmpty().WithMessage("El campo Username es requerido");
            }
        }

        public class AddUserHandler : IRequestHandler<AddUserRequest, UserDTO>
        {
            private readonly InternetControlContext _Context;
            private readonly UserManager<User> _userManager;
            private readonly IJWTGenerator _iJWTGenerator;
            public AddUserHandler(InternetControlContext Context, UserManager<User> userManager, IJWTGenerator iJWTGenerator)
            {
                this._Context = Context;
                this._userManager = userManager;
                this._iJWTGenerator = iJWTGenerator;
            }

            public async Task<UserDTO> Handle(AddUserRequest request, CancellationToken cancellationToken)
            {
                var existe = await _Context.Users.Where(x => x.Email == request.Email).AnyAsync();
                if(existe){
                    throw new Exception("Ya existe un usuario registrado con ese email");
                }

                var existeUserName = await _Context.Users.Where(x => x.UserName == request.UserName).AnyAsync();
                if(existeUserName){
                    throw new Exception("Ya existe un usuario registrado con ese UserName");
                }

                var user = new User{
                    NombreCompleto = request.Nombres + " " + request.Apellidos,
                    Email = request.Email,
                    UserName = request.UserName
                };
                var resultado = await _userManager.CreateAsync(user, request.Password);

                if(resultado.Succeeded){
                    return new UserDTO{
                        NombreCompleto = user.NombreCompleto,
                        Token = _iJWTGenerator.GenerateToken(user, null),
                        UserName = user.UserName,
                        Email = user.Email                        
                    };
                }
                throw new Exception("No se pudo agregar el nuevo usuario");
            }
        }

        //EDITAR USUARIO
        public class EditUserRequest : IRequest<UserDTO>
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
        }

        public class EditUserValidator : AbstractValidator<EditUserRequest>
        {
            public EditUserValidator()
            {
                RuleFor(x => x.Nombres).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
            }
        }

        public class EditUserHandler : IRequestHandler<EditUserRequest, UserDTO>
        {
            private readonly InternetControlContext _context;
            private readonly UserManager<User> _userManager;
            private readonly IJWTGenerator _jwtGenerador;

            private readonly IPasswordHasher<User> _passwordHasher;

            public EditUserHandler(InternetControlContext context, UserManager<User> userManager, IJWTGenerator jwtGenerador, 
            IPasswordHasher<User> passwordHasher)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _passwordHasher = passwordHasher;
            }

            public async Task<UserDTO> Handle(EditUserRequest request, CancellationToken cancellationToken)
            {
                var usuarioIden = await _userManager.FindByNameAsync(request.Username);
                if (usuarioIden == null)
                {
                    throw new CustomExceptionHelper(HttpStatusCode.NotFound, new { mensaje = "No existe un usuario con este username" });
                }

                var resultado = await _context.Users.Where(x => x.Email == request.Email && x.UserName != request.Username).AnyAsync();
                if (resultado)
                {
                    throw new CustomExceptionHelper(HttpStatusCode.InternalServerError, new { mensaje = "Este email pertenece a otro usuario" });
                }

                usuarioIden.NombreCompleto = request.Nombres + " " + request.Apellidos;
                usuarioIden.PasswordHash = _passwordHasher.HashPassword(usuarioIden, request.Password);
                usuarioIden.Email = request.Email;

                var resultadoUpdate = await _userManager.UpdateAsync(usuarioIden);

                var resultadoRoles = await _userManager.GetRolesAsync(usuarioIden);
                var listRoles = new List<string>(resultadoRoles);

                if (resultadoUpdate.Succeeded)
                {
                    return new UserDTO
                    {
                        NombreCompleto = usuarioIden.NombreCompleto,
                        UserName = usuarioIden.UserName,
                        Email = usuarioIden.Email,
                        Token = _jwtGenerador.GenerateToken(usuarioIden, listRoles),
                    };
                }

                throw new System.Exception("No se pudo actualizar el usuario");

            }

        }
 

        //ADD ROLE A USUARIO
        public class AddRoleToUserRequest : IRequest {
            public string Username{get;set;}
            public string RolNombre {get;set;}
        }

        public class AddRoleToUserValidator : AbstractValidator<AddRoleToUserRequest>{
            public AddRoleToUserValidator(){
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.RolNombre).NotEmpty();
            }
        }

        public class AddRoleToUserHandler : IRequestHandler<AddRoleToUserRequest>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public AddRoleToUserHandler(UserManager<User>  userManager, RoleManager<IdentityRole> roleManager){
                _userManager = userManager;
                _roleManager = roleManager;
            }
            
            public async Task<Unit> Handle(AddRoleToUserRequest request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(request.RolNombre);
                if(role == null) {
                    throw new CustomExceptionHelper(HttpStatusCode.NotFound,new {mensaje = "El rol no existe"});
                }

                var usuarioIden = await _userManager.FindByNameAsync(request.Username);
                if(usuarioIden == null){
                    throw new CustomExceptionHelper(HttpStatusCode.NotFound, new {mensaje ="El usuario no existe"});
                }

                var resultado =  await _userManager.AddToRoleAsync(usuarioIden, request.RolNombre);
                if(resultado.Succeeded){
                    return Unit.Value;
                }

                throw new Exception("No se pudo agregar el Rol al usuario");
            }
        }

        //DELETE ROLE A USUARIO
        public class DeleteRoleToUserRequest : IRequest{
            public string Username {get;set;}
            public string RolNombre {get;set;}
        }

        public class DeleteRoleToUserValidator : AbstractValidator<DeleteRoleToUserRequest> {
                public DeleteRoleToUserValidator(){
                    RuleFor(x => x.Username).NotEmpty();
                    RuleFor(x => x.RolNombre).NotEmpty();
                }
        }

        public class DeleteRoleToUserHandler : IRequestHandler<DeleteRoleToUserRequest>
        {
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            
            public DeleteRoleToUserHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager){
                _userManager = userManager;
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle(DeleteRoleToUserRequest request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(request.RolNombre);
                if(role==null){
                    throw new CustomExceptionHelper(HttpStatusCode.NotFound, new {mensaje = "No se encontro el rol"});
                }

                var usuarioIden = await _userManager.FindByNameAsync(request.Username);
                if(usuarioIden==null){
                    throw new CustomExceptionHelper(HttpStatusCode.NotFound, new {mensaje = "No se encontro el usuario"});
                }

                var resultado = await _userManager.RemoveFromRoleAsync(usuarioIden, request.RolNombre);
                if(resultado.Succeeded){
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el rol");
            }
        } 

    }
}