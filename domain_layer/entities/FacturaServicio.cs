using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class FacturaServicio
    {
        public long IdemisionCable { get; set; }
        public string StrIdsucursal { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public int IdservicioAdicional { get; set; }
        public double Cantidad { get; set; }
        public decimal CostoServicio { get; set; }
        public bool AplicaIva { get; set; }
        public double? SubtotalAplicaIva { get; set; }
        public double? SubtotalNoAplicaIva { get; set; }

        public virtual DetalleEmisionServicioCable DetalleEmisionServicioCable { get; set; }
        public virtual ServicioAdicional IdservicioAdicionalNavigation { get; set; }
    }
}
