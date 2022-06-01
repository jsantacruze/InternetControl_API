using System.Collections.Generic;

namespace business_layer.DTO
{
    public class UsuarioDTO
    {
        public string CedulaEmpleado { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool? Activo { get; set; }

        public virtual EmpleadoDTO Empleado { get; set; }
        public virtual List<UsuarioGrupoDTO> UsuarioGrupos { get; set; }

    }
}