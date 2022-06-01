using System.Collections.Generic;

namespace business_layer.DTO
{
    public class GrupoUsuarioDTO
    {
        public string Idgrupo { get; set; }
        public string Nombre { get; set; }

        public List<PermisoGrupoDTO> PermisoGrupos { get; set; }
    }
}