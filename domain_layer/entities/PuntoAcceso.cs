using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class PuntoAcceso
    {
        public PuntoAcceso()
        {
            DetalleEmisionServicioCables = new HashSet<DetalleEmisionServicioCable>();
            EmisionServicioCables = new HashSet<EmisionServicioCable>();
        }

        public int IntIdpuntoAcceso { get; set; }
        public string StrIdsucursal { get; set; }
        public string StrDescripcionPunto { get; set; }
        public string StrObservaciones { get; set; }
        public bool BlnActivo { get; set; }

        public virtual Sucursal StrIdsucursalNavigation { get; set; }
        public virtual ICollection<DetalleEmisionServicioCable> DetalleEmisionServicioCables { get; set; }
        public virtual ICollection<EmisionServicioCable> EmisionServicioCables { get; set; }
    }
}
