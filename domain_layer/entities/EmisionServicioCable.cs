using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class EmisionServicioCable
    {
        public EmisionServicioCable()
        {
            DetalleEmisionServicioCables = new HashSet<DetalleEmisionServicioCable>();
        }

        public long IdemisionCable { get; set; }
        public string StrIdsucursal { get; set; }
        public DateTime FechaEmision { get; set; }
        public bool EmisionActiva { get; set; }
        public string IdusuarioCreador { get; set; }
        public string ObservacionesEmision { get; set; }
        public int IdanioGenracion { get; set; }
        public int IdmesGeneracion { get; set; }
        public int IdanioConsumo { get; set; }
        public int IdmesCosnumo { get; set; }
        public int IdpuntoAccesoGenera { get; set; }
        public string IdsucursalGenera { get; set; }
        public long? InicioRangoFactura { get; set; }
        public long? FinRangoFactura { get; set; }
        public long? InicioRangoComprobante { get; set; }
        public long? FinRangoComprobante { get; set; }

        public virtual AnioMe Id { get; set; }
        public virtual PuntoAcceso Id1 { get; set; }
        public virtual AnioMe IdNavigation { get; set; }
        public virtual Usuario IdusuarioCreadorNavigation { get; set; }
        public virtual Sucursal StrIdsucursalNavigation { get; set; }
        public virtual ICollection<DetalleEmisionServicioCable> DetalleEmisionServicioCables { get; set; }
    }
}
