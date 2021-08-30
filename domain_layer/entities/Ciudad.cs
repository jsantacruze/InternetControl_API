using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Empleados = new HashSet<Empleado>();
            SectorCiudads = new HashSet<SectorCiudad>();
            Sucursals = new HashSet<Sucursal>();
            Suscriptors = new HashSet<Suscriptor>();
        }

        public string StrIdciudad { get; set; }
        public string StrDescripcionCiudad { get; set; }
        public string StrObservaciones { get; set; }
        public string StrIdprovincia { get; set; }

        public virtual Provincium StrIdprovinciaNavigation { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<SectorCiudad> SectorCiudads { get; set; }
        public virtual ICollection<Sucursal> Sucursals { get; set; }
        public virtual ICollection<Suscriptor> Suscriptors { get; set; }
    }
}
