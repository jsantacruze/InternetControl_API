using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class ServicioAdicional
    {
        public ServicioAdicional()
        {
            FacturaServicios = new HashSet<FacturaServicio>();
            ServicioSuscripcions = new HashSet<ServicioSuscripcion>();
        }

        public int IdservicioAdicional { get; set; }
        public string DescripcionServicioAdicional { get; set; }
        public decimal CostoServicioAdicional { get; set; }
        public bool ServicioActivo { get; set; }
        public bool AplicaIva { get; set; }
        public string ObservacionesServicioAdicional { get; set; }

        public virtual ICollection<FacturaServicio> FacturaServicios { get; set; }
        public virtual ICollection<ServicioSuscripcion> ServicioSuscripcions { get; set; }
    }
}
