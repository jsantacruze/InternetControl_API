using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class UbicacionEnlace
    {
        public UbicacionEnlace()
        {
            PuntoAccesoServicios = new HashSet<PuntoAccesoServicio>();
            TorreDistribucions = new HashSet<TorreDistribucion>();
        }

        public string Idubicacion { get; set; }
        public string DescripcionUbicacion { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<PuntoAccesoServicio> PuntoAccesoServicios { get; set; }
        public virtual ICollection<TorreDistribucion> TorreDistribucions { get; set; }
    }
}
