using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class EquipoEnlaceCliente
    {
        public EquipoEnlaceCliente()
        {
            Suscripcions = new HashSet<Suscripcion>();
        }

        public int Idequipo { get; set; }
        public string Descripcion { get; set; }
        public string NumeroSerie { get; set; }
        public string DireccionMac { get; set; }
        public string Marca { get; set; }
        public DateTime? FechaCompra { get; set; }
        public byte[] Imagen { get; set; }
        public string Observaciones { get; set; }
        public string IdtipoEquipo { get; set; }

        public virtual TipoEquipo IdtipoEquipoNavigation { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
