using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class DetalleEmisionServicioCable
    {
        public DetalleEmisionServicioCable()
        {
            FacturaServicios = new HashSet<FacturaServicio>();
        }

        public long IdemisionCable { get; set; }
        public string StrIdsucursal { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public long NumeroDocumento { get; set; }
        public double Intereses { get; set; }
        public bool ServicioPagado { get; set; }
        public double AbonoRealizado { get; set; }
        public DateTime FechaPago { get; set; }
        public double PorcentajeIvaaplicado { get; set; }
        public double Ivacobrado { get; set; }
        public bool Anulada { get; set; }
        public DateTime FechaAnulacion { get; set; }
        public string IdusuarioCobrador { get; set; }
        public string IduusarioAnulador { get; set; }
        public bool Sincronizado { get; set; }
        public DateTime FechaSicronizacion { get; set; }
        public string IdusuarioSincronizador { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public long? NumeroComprobanteReal { get; set; }
        public long? NumeroFacturaReal { get; set; }
        public bool Tag1 { get; set; }
        public double Tag2 { get; set; }
        public decimal Tag3 { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public decimal SubtotalSinIva { get; set; }
        public decimal SubtotalConIva { get; set; }
        public decimal CobrosAdicionales { get; set; }
        public string ObservacionesFactura { get; set; }
        public int NumMesesCobrados { get; set; }
        public string IdusuarioCreador { get; set; }
        public int IdpuntoAccesoCobro { get; set; }
        public string IdsucursalCobro { get; set; }
        public int? EquiposIncluidosFactura { get; set; }
        public decimal? CostoEquiposIncluidosFactura { get; set; }
        public int? EquiposAdicionalesFactura { get; set; }
        public decimal? CostoEquiposAdicionalesFactura { get; set; }
        public string NroSerialRetencion { get; set; }
        public string AutSriretencion { get; set; }
        public DateTime? FechaAutorizacionRetencion { get; set; }
        public DateTime? FechaValidezComprobanteRetencion { get; set; }
        public double? PorcentajeRetRenta { get; set; }
        public string CodigoImpuestoRenta { get; set; }
        public double? PorcentajeRetencionIva { get; set; }
        public string ComdigoImpuestiIva { get; set; }
        public bool EnviarFactura { get; set; }
        public long? IddocumentoElectronico { get; set; }

        public virtual EmisionServicioCable EmisionServicioCable { get; set; }
        public virtual PuntoAcceso Id { get; set; }
        public virtual DocumentoElectronico IddocumentoElectronicoNavigation { get; set; }
        public virtual Usuario IdusuarioCobradorNavigation { get; set; }
        public virtual Usuario IdusuarioCreadorNavigation { get; set; }
        public virtual Usuario IdusuarioSincronizadorNavigation { get; set; }
        public virtual Usuario IduusarioAnuladorNavigation { get; set; }
        public virtual Suscripcion Suscripcion { get; set; }
        public virtual ICollection<FacturaServicio> FacturaServicios { get; set; }
    }
}
