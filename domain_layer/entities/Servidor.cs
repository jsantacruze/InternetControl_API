using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Servidor
    {
        public Servidor()
        {
            PuntoAccesoServicios = new HashSet<PuntoAccesoServicio>();
        }

        public int ServidorId { get; set; }
        public string ServidorNombre { get; set; }
        public string ServidorMarca { get; set; }
        public string ServidorIpv4 { get; set; }
        public string ServidorIpv6 { get; set; }
        public string ServidorUser { get; set; }
        public string ServidorPassword { get; set; }
        public string ServidorMacAddress { get; set; }
        public int? ServidorPuerto { get; set; }
        public string ServidorObservaciones { get; set; }

        public virtual ICollection<PuntoAccesoServicio> PuntoAccesoServicios { get; set; }
    }
}
