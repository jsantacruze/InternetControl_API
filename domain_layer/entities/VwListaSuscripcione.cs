using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class VwListaSuscripcione
    {
        public string StrCedulaRuc { get; set; }
        public string StrApellidos { get; set; }
        public string StrNombres { get; set; }
        public string StrRazonSocial { get; set; }
        public bool BlnActivo { get; set; }
        public double DblPorcentajeDescuento { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public string StrDescripcionSucursal { get; set; }
        public bool SuscripcionActiva { get; set; }
        public double CostoInstalacion { get; set; }
        public int EquiposIncluidos { get; set; }
        public int EquiposAdicionales { get; set; }
        public double ValorMensualEquipos { get; set; }
        public double ValorMensualAdicionales { get; set; }
        public string DireccionSuscripcion { get; set; }
        public string ReferenciaSuscripcion { get; set; }
        public int StrIdsector { get; set; }
        public string DescripcionSector { get; set; }
    }
}
