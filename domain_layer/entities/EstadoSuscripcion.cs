using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class EstadoSuscripcion
    {
        public EstadoSuscripcion()
        {
            Suscripcions = new HashSet<Suscripcion>();
        }

        public string IdestadoSuscripcion { get; set; }
        public string DescripcionEstadoSuscripcion { get; set; }

        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
