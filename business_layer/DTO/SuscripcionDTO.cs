using System;

namespace business_layer.DTO
{
    public class SuscripcionDTO
    {
        public long DblCodigoSuscripcion { get; set; }
        public DateTime FechaSuscripcion { get; set; }
        public string StrIdsucursal { get; set; }
        public int StrIdsector { get; set; }
        public double CodigoSuscriptor { get; set; }
        public string DireccionSuscripcion { get; set; }
        public SuscriptorDTO CodigoSuscriptorNavigation{get; set;}

    }
}