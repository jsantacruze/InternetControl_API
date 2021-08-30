using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class GrupoUsuario
    {
        public GrupoUsuario()
        {
            PermisoGrupos = new HashSet<PermisoGrupo>();
            UsuarioGrupos = new HashSet<UsuarioGrupo>();
        }

        public string Idgrupo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PermisoGrupo> PermisoGrupos { get; set; }
        public virtual ICollection<UsuarioGrupo> UsuarioGrupos { get; set; }
    }
}
