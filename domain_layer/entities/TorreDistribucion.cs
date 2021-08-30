using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class TorreDistribucion
    {
        public TorreDistribucion()
        {
            PuntoAccesoServicios = new HashSet<PuntoAccesoServicio>();
        }

        public int TorreId { get; set; }
        public string TorreDescripcion { get; set; }
        public double? TorreLatitud { get; set; }
        public double? TorreLongitud { get; set; }
        public string TorreObservaciones { get; set; }
        public string TorreUbicacionId { get; set; }
        public byte[] TorreImagen { get; set; }
        public string TorreTiempoReservaBaterias { get; set; }
        public int? TorreNumSuscriptores { get; set; }

        public virtual UbicacionEnlace TorreUbicacion { get; set; }
        public virtual ICollection<PuntoAccesoServicio> PuntoAccesoServicios { get; set; }
    }
}
