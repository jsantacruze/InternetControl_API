using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class VwReporteGeneralRecuadacionFacElectronica
    {
        public long IddocumentoElectronico { get; set; }
        public string ClaveAcceso { get; set; }
        public string TipoDocumentoElectronico { get; set; }
        public bool Generado { get; set; }
        public bool Firmado { get; set; }
        public bool Recibido { get; set; }
        public string RespuestaRecepcion { get; set; }
        public string MensajeRecepcion { get; set; }
        public bool Autorizado { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string FechaAutorizacion { get; set; }
        public string MensajeAutorizacion { get; set; }
        public string MensajeAdicionalAutorizacion { get; set; }
        public string Ambiente { get; set; }
        public bool MailEnviado { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string DireccionMatriz { get; set; }
        public string DireccionSucursal { get; set; }
        public string NroContribuyenteEspecial { get; set; }
        public string ObligadoContabilidad { get; set; }
        public bool PendienteRecuperar { get; set; }
        public bool RideGenerado { get; set; }
        public string Ruc { get; set; }
        public string NumeroSerial { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal? TotalFactura { get; set; }
        public bool ServicioPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public bool SuscripcionActiva { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public bool MarcadoEnvioEbilling { get; set; }
        public string PeriodoConsumo { get; set; }
        public string StrCedulaRuc { get; set; }
        public string StrNombres { get; set; }
        public string StrApellidos { get; set; }
        public string StrRazonSocial { get; set; }
        public string StrDireccion { get; set; }
        public string StrTelefono { get; set; }
        public string StrMovil { get; set; }
        public string StrEmail { get; set; }
        public decimal? BaseImponible { get; set; }
        public decimal? Ivacobrado { get; set; }
        public decimal? TotalRecaudado { get; set; }
    }
}
