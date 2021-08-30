using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Bitacora
    {
        public long Idoperacion { get; set; }
        public string IdusuarioSistema { get; set; }
        public string IdmoduloSistema { get; set; }
        public string DetalleOperacion { get; set; }
        public string DireccionIp { get; set; }
        public string DireccionMac { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }

        public virtual ModuloSistema IdmoduloSistemaNavigation { get; set; }
        public virtual Usuario IdusuarioSistemaNavigation { get; set; }
    }
}
