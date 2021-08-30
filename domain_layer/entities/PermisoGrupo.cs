using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class PermisoGrupo
    {
        public string Idgrupo { get; set; }
        public string Idproceso { get; set; }

        public virtual GrupoUsuario IdgrupoNavigation { get; set; }
        public virtual ProcesoSistema IdprocesoNavigation { get; set; }
    }
}
