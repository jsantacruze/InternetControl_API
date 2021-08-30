using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class ProcesoSistema
    {
        public ProcesoSistema()
        {
            PermisoGrupos = new HashSet<PermisoGrupo>();
        }

        public string Idproceso { get; set; }
        public string DescripcionProceso { get; set; }
        public int IdcategoriaProceso { get; set; }

        public virtual CategoriaProcesoSistema IdcategoriaProcesoNavigation { get; set; }
        public virtual ICollection<PermisoGrupo> PermisoGrupos { get; set; }
    }
}
