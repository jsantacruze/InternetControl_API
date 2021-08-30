using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class UsuarioGrupo
    {
        public string CedulaUsuario { get; set; }
        public string Idgrupo { get; set; }

        public virtual Usuario CedulaUsuarioNavigation { get; set; }
        public virtual GrupoUsuario IdgrupoNavigation { get; set; }
    }
}
