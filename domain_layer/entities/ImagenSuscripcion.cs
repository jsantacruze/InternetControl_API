using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class ImagenSuscripcion
    {
        public long ImagenId { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public string StrIdsucursal { get; set; }
        public string ImagenDescripcion { get; set; }
        public byte[] ImagenValue { get; set; }
        public bool ImagenPrincipal { get; set; }

        public virtual Suscripcion Suscripcion { get; set; }
    }
}
