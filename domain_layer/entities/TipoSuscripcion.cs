using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class TipoSuscripcion
    {
        public TipoSuscripcion()
        {
            Suscripcions = new HashSet<Suscripcion>();
        }

        public int TipoId { get; set; }
        public string TipoDescripcion { get; set; }

        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
