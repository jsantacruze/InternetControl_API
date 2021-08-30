using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class VwModeloConfiguracionPuntoAcceso
    {
        public int IntIdpuntoAcceso { get; set; }
        public string StrIdsucursal { get; set; }
        public string StrDescripcionPunto { get; set; }
        public string ObservacionesPunto { get; set; }
        public string StrDescripcionSucursal { get; set; }
        public string StrDireccionSucursal { get; set; }
        public string StrDescripcionCiudad { get; set; }
        public string StrDescripcionProvincia { get; set; }
        public string StrCedulaResponsable { get; set; }
        public string Responsable { get; set; }
    }
}
