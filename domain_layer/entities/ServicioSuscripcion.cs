using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class ServicioSuscripcion
    {
        public string StrIdsucursal { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public int IdservicioAdicional { get; set; }
        public bool ServicioActivo { get; set; }

        public virtual ServicioAdicional IdservicioAdicionalNavigation { get; set; }
        public virtual Suscripcion Suscripcion { get; set; }
    }
}
