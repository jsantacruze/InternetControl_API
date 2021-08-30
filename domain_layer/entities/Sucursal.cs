using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            EmisionServicioCables = new HashSet<EmisionServicioCable>();
            Empleados = new HashSet<Empleado>();
            PuntoAccesos = new HashSet<PuntoAcceso>();
            Suscripcions = new HashSet<Suscripcion>();
        }

        public string StrIdsucursal { get; set; }
        public string StrDescripcionSucursal { get; set; }
        public string StrIdciudad { get; set; }
        public string StrDireccionSucursal { get; set; }
        public string StrTelefono { get; set; }
        public string StrMovil { get; set; }
        public string StrEmail { get; set; }
        public string StrFax { get; set; }
        public string StrCedulaResponsable { get; set; }
        public double? DblLatitud { get; set; }
        public double? DblLongitud { get; set; }
        public byte[] ImgFoto { get; set; }

        public virtual Empleado StrCedulaResponsableNavigation { get; set; }
        public virtual Ciudad StrIdciudadNavigation { get; set; }
        public virtual ICollection<EmisionServicioCable> EmisionServicioCables { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<PuntoAcceso> PuntoAccesos { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
