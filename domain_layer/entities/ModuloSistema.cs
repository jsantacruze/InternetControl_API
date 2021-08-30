using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class ModuloSistema
    {
        public ModuloSistema()
        {
            Bitacoras = new HashSet<Bitacora>();
        }

        public string Idmodulo { get; set; }
        public string DescripcionModulo { get; set; }

        public virtual ICollection<Bitacora> Bitacoras { get; set; }
    }
}
