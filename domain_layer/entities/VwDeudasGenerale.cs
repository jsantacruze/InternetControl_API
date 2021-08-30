using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class VwDeudasGenerale
    {
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
        public DateTime FechaSuscripcion { get; set; }
        public int StrIdsector { get; set; }
        public string DescripcionSector { get; set; }
        public string CiudadSector { get; set; }
        public string CedulaRucsuscriptor { get; set; }
        public string NombresSuscriptor { get; set; }
        public string ApellidosSuscriptor { get; set; }
        public string Suscriptor { get; set; }
        public string RazonSocialSuscriptor { get; set; }
        public string DireccionSuscriptor { get; set; }
        public string TelefonoSuscriptor { get; set; }
        public string MovilSuscriptor { get; set; }
        public string EmailSuscriptor { get; set; }
        public bool SuscriptorActivo { get; set; }
        public bool SuscriptorPersonaNatural { get; set; }
        public double SuscriptorPorcentajeDescuento { get; set; }
        public string ObservacionesSuscriptor { get; set; }
        public double CodigoSuscriptor { get; set; }
        public bool SuscripcionActiva { get; set; }
        public double CostoInstalacion { get; set; }
        public int EquiposIncluidos { get; set; }
        public int EquiposAdicionales { get; set; }
        public double ValorMensualEquipos { get; set; }
        public double ValorMensualAdicionales { get; set; }
        public string ObservacionesSuscripcion { get; set; }
        public string IdestadoSuscripcion { get; set; }
        public string DescripcionEstadoSuscripcion { get; set; }
        public string DireccionSuscripcion { get; set; }
        public string ReferenciaSuscripcion { get; set; }
        public string UserIdcobrador { get; set; }
        public string UsuarioCobrador { get; set; }
        public string UserIdusuarioAnulador { get; set; }
        public string UsuarioAnulador { get; set; }
        public string UserIdsincronizador { get; set; }
        public string UsuarioSincronizador { get; set; }
        public string UserIdcreador { get; set; }
        public string UsuarioCreador { get; set; }
        public string PuntoAccesoCobro { get; set; }
        public int? EquiposIncluidosFactura { get; set; }
        public decimal? CostoEquiposIncluidosFactura { get; set; }
        public int? EquiposAdicionalesFactura { get; set; }
        public decimal? CostoEquiposAdicionalesFactura { get; set; }
        public string MesAnioGeneracion { get; set; }
        public string MesAnioConsumo { get; set; }
        public double? Subtotalserviciossiniva { get; set; }
        public double? Subtotalserviciosconiva { get; set; }
        public double? Subtotalsinivafactura { get; set; }
        public double? Subtotalconivafactura { get; set; }
        public double? Descuentosinivafactura { get; set; }
        public double? Descuentoconivafactura { get; set; }
        public double? Descuentototalfactura { get; set; }
        public double? Baseimponiblefactura { get; set; }
        public double? Ivacobradofactura { get; set; }
        public double? Icecobradofactura { get; set; }
        public double? Totalapagar { get; set; }
        public string StrDescripcionSucursal { get; set; }
    }
}
