using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using business_layer.DTO;
using business_layer.ExceptionManager;
using business_layer.IdentitySecurity.Contracts;
using data_access;
using domain_layer.entities;
using domain_layer.Security;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

            private readonly InternetControlContext _context;
            private readonly IMapper _mapper;

            public LoginHandler(UserManager<User> userManager, SignInManager<User> signInManager, IJWTGenerator iJWTGenerator, InternetControlContext context 
                , IMapper mapper){
                _userManager = userManager;
                _signInManager = signInManager;
                _iJWTGenerator = iJWTGenerator;
                _context = context;
                _mapper = mapper;
            }
            public async Task<UserDTO> Handle(LoginRequest request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if(usuario == null){
                    throw new CustomExceptionHelper(HttpStatusCode.NotFound, new { mensaje = "No existe ningún usuario con el email especificado" });
                }
                var result = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);
                var rolesResult = await _userManager.GetRolesAsync(usuario);
                var rolesList = new List<String>(rolesResult);
                if(result.Succeeded){
                    var userDesktop = _context.Usuarios
                                        .Include(ud => ud.CedulaEmpleadoNavigation)
                                        .Include(ud => ud.UsuarioGrupos.Select(ug => ug.IdgrupoNavigation.PermisoGrupos.Select(pg => pg.IdprocesoNavigation)))
                                        .FirstOrDefault(ud => ud.CedulaEmpleadoNavigation.StrEmail == usuario.Email);
                    var userDesktopDTO = _mapper.Map<Usuario, UsuarioDTO>(userDesktop);
                    return new UserDTO{
                        NombreCompleto = usuario.NombreCompleto,                       
                        Token = _iJWTGenerator.GenerateToken(usuario, rolesList),
                        Email = usuario.Email,
                        UserName = usuario.UserName,
                        Imagen = null,
                        usuarioDesktop = userDesktopDTO 
                    };
                }
                throw new CustomExceptionHelper(HttpStatusCode.NotFound, new { mensaje = "Clave inválida" });
            }
        }

            public class CurrentUserRequest: IRequest<UserDTO>{
            }

        public class CurrentUserHandler : IRequestHandler<CurrentUserRequest, UserDTO>
        {
            private readonly UserManager<User> _userManager;
            private readonly IJWTGenerator _jWTGenerator;
            private readonly ISessionUser _sessionUser;
            private readonly InternetControlContext _context;

            public CurrentUserHandler(UserManager<User> userManager, IJWTGenerator jWTGenerator, ISessionUser sessionUser,
             InternetControlContext context){
                _userManager = userManager;
                _jWTGenerator = jWTGenerator;
                _sessionUser = sessionUser;
                _context = context;
            }
            public async Task<UserDTO> Handle(CurrentUserRequest request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByNameAsync(_sessionUser.getSessionUser());
                var rolesResult = await _userManager.GetRolesAsync(usuario);
                var rolesList = new List<String>(rolesResult);
                var empleadoBD = await _context.Empleados.Where(e => e.StrEmail.Equals(usuario.Email))
                .FirstOrDefaultAsync();

                return new UserDTO{
                    NombreCompleto = usuario.NombreCompleto,
                    UserName = usuario.UserName,
                    Token = _jWTGenerator.GenerateToken(usuario, rolesList),
                    Imagen = null,
                    Email = usuario.Email,
                    empleado = new EmpleadoDTO{
                            StrCedulaRuc = empleadoBD.StrCedulaRuc,
                            StrNombres = empleadoBD.StrNombres,
                            StrApellidos = empleadoBD.StrApellidos,
                            StrDireccion = empleadoBD.StrDireccion,
                            StrTelefono = empleadoBD.StrTelefono,
                            StrMovil = empleadoBD.StrMovil,
                            StrEmail = empleadoBD.StrEmail,
                            BlnActivo = empleadoBD.BlnActivo
                    }
                };
            }
        }

    }
}