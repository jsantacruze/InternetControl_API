using System.Collections.Generic;

namespace business_layer.DTO
{
    public class TorreDistribucionDTO
    {
        public int TorreId { get; set; }
        public string TorreDescripcion { get; set; }
        public double? TorreLatitud { get; set; }
        public double? TorreLongitud { get; set; }
        public string TorreObservaciones { get; set; }
        public string TorreUbicacionId { get; set; }
        public byte[] TorreImagen { get; set; }
        public string TorreTiempoReservaBaterias { get; set; }
        public int? TorreNumSuscriptores { get; set; }

        public virtual UbicacionEnlaceDTO TorreUbicacion { get; set; }

        public List<PuntoAccesoServicioDTO> PuntoAccesoServicios { get; set; }

   
    }
}