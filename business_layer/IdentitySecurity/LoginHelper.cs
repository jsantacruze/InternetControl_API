using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using business_layer.DTO;
using business_layer.IdentitySecurity.Contracts;
using domain_layer.Security;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace business_layer.IdentitySecurity
{
    public class LoginHelper
    {
        public class LoginRequest: IRequest<UserDTO>{
            public string Email {get; set;}
            public string Password{get; set;}
        }
        public class LoginValidator: AbstractValidator<LoginRequest>{
            public LoginValidator(){
                RuleFor(x => x.Email).NotEmpty().WithMessage("El email es requerido");
                RuleFor(x => x.Password).NotEmpty().WithMessage("El password es requerido");
            }
        }
        public class LoginHandler : IRequestHandler<LoginRequest, UserDTO>
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            private readonly IJWTGenerator _iJWTGenerator;
            public LoginHandler(UserManager<User> userManager, SignInManager<User> signInManager, IJWTGenerator iJWTGenerator){
                _userManager = userManager;
                _signInManager = signInManager;
                _iJWTGenerator = iJWTGenerator;
            }
            public async Task<UserDTO> Handle(LoginRequest request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if(usuario == null){
                    throw new Exception("El usuario no existe");
                }
                var result = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);
                var rolesResult = await _userManager.GetRolesAsync(usuario);
                var rolesList = new List<String>(rolesResult);

                if(result.Succeeded){
                    return new UserDTO{
                        NombreCompleto = usuario.NombreCompleto,
                        Token = _iJWTGenerator.GenerateToken(usuario, rolesList),
                        Email = usuario.Email,
                        UserName = usuario.UserName,
                        Imagen = null
                    };
                }
                throw new Exception("Clave inválida");
            }
        }

            public class CurrentUserRequest: IRequest<UserDTO>{
            }

        public class CurrentUserHandler : IRequestHandler<CurrentUserRequest, UserDTO>
        {
            private readonly UserManager<User> _userManager;
            private readonly IJWTGenerator _jWTGenerator;
            private readonly ISessionUser _sessionUser;
            public CurrentUserHandler(UserManager<User> userManager, IJWTGenerator jWTGenerator, ISessionUser sessionUser){
                _userManager = userManager;
                _jWTGenerator = jWTGenerator;
                _sessionUser = sessionUser;
            }
            public async Task<UserDTO> Handle(CurrentUserRequest request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByNameAsync(_sessionUser.getSessionUser());
                var rolesResult = await _userManager.GetRolesAsync(usuario);
                var rolesList = new List<String>(rolesResult);
                return new UserDTO{
                    NombreCompleto = usuario.NombreCompleto,
                    UserName = usuario.UserName,
                    Token = _jWTGenerator.GenerateToken(usuario, rolesList),
                    Imagen = null,
                    Email = usuario.Email
                };
            }
        }

    }
}