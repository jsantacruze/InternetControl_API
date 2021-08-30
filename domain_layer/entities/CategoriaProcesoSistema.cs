using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class CategoriaProcesoSistema
    {
        public CategoriaProcesoSistema()
        {
            ProcesoSistemas = new HashSet<ProcesoSistema>();
        }

        public int IdcategoriaProceso { get; set; }
        public string DescripcionCategoriaProceso { get; set; }

        public virtual ICollection<ProcesoSistema> ProcesoSistemas { get; set; }
    }
}
