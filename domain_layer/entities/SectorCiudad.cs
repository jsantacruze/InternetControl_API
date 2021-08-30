using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class SectorCiudad
    {
        public SectorCiudad()
        {
            Suscripcions = new HashSet<Suscripcion>();
        }

        public int Idsector { get; set; }
        public string StrIdciudad { get; set; }
        public string DescripcionSector { get; set; }
        public string Referencia { get; set; }

        public virtual Ciudad StrIdciudadNavigation { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
