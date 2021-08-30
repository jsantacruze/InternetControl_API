using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Empleado
    {
        public Empleado()
        {
            Sucursals = new HashSet<Sucursal>();
            TrackingSuscripcions = new HashSet<TrackingSuscripcion>();
        }

        public string StrCedulaRuc { get; set; }
        public string StrNombres { get; set; }
        public string StrApellidos { get; set; }
        public string StrIdciudad { get; set; }
        public string StrDireccion { get; set; }
        public string StrIdsexo { get; set; }
        public string StrTelefono { get; set; }
        public string StrMovil { get; set; }
        public string StrEmail { get; set; }
        public byte[] ImgFoto { get; set; }
        public double? DblSueldo { get; set; }
        public string StrCargo { get; set; }
        public DateTime? DtFechaIngreso { get; set; }
        public DateTime? DtFechaEgreso { get; set; }
        public string StrObservaciones { get; set; }
        public bool BlnActivo { get; set; }
        public string StrIdsucursalPertenece { get; set; }

        public virtual Ciudad StrIdciudadNavigation { get; set; }
        public virtual Sexo StrIdsexoNavigation { get; set; }
        public virtual Sucursal StrIdsucursalPerteneceNavigation { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Sucursal> Sucursals { get; set; }
        public virtual ICollection<TrackingSuscripcion> TrackingSuscripcions { get; set; }
    }
}
