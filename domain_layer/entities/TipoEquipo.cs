using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class TipoEquipo
    {
        public TipoEquipo()
        {
            EquipoEnlaceClientes = new HashSet<EquipoEnlaceCliente>();
            PuntoAccesoServicios = new HashSet<PuntoAccesoServicio>();
        }

        public string IdtipoEquipo { get; set; }
        public string DescripcionTipo { get; set; }
        public string ObservacionesTipo { get; set; }

        public virtual ICollection<EquipoEnlaceCliente> EquipoEnlaceClientes { get; set; }
        public virtual ICollection<PuntoAccesoServicio> PuntoAccesoServicios { get; set; }
    }
}
