using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class VwValoresPagar
    {
        public string StrDescripcionSucursal { get; set; }
        public string DescripcionSector { get; set; }
        public double DblCodigoSuscriptor { get; set; }
        public string StrCedulaRuc { get; set; }
        public string StrApellidos { get; set; }
        public string StrNombres { get; set; }
        public string StrRazonSocial { get; set; }
        public string StrTelefono { get; set; }
        public string StrMovil { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public string StrIdsucursal { get; set; }
        public bool Activo { get; set; }
        public double CostoInstalacion { get; set; }
        public int EquiposIncluidos { get; set; }
        public int EquiposAdicionales { get; set; }
        public double ValorMensualEquipos { get; set; }
        public double ValorMensualAdicionales { get; set; }
        public string DireccionSuscripcion { get; set; }
    }
}
