using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Suscripcion
    {
        public Suscripcion()
        {
            DetalleEmisionServicioCables = new HashSet<DetalleEmisionServicioCable>();
            ImagenSuscripcions = new HashSet<ImagenSuscripcion>();
            ServicioSuscripcions = new HashSet<ServicioSuscripcion>();
            TrackingSuscripcions = new HashSet<TrackingSuscripcion>();
        }

        public long DblCodigoSuscripcion { get; set; }
        public DateTime FechaSuscripcion { get; set; }
        public string StrIdsucursal { get; set; }
        public int StrIdsector { get; set; }
        public double CodigoSuscriptor { get; set; }
        public bool Activo { get; set; }
        public string StrCedulaUsuarioCreador { get; set; }
        public double CostoInstalacion { get; set; }
        public int EquiposIncluidos { get; set; }
        public int EquiposAdicionales { get; set; }
        public double ValorMensualEquipos { get; set; }
        public double ValorMensualAdicionales { get; set; }
        public string Observaciones { get; set; }
        public string IdestadoSuscripcion { get; set; }
        public byte[] ImgFotoInstalacion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string DireccionSuscripcion { get; set; }
        public string ReferenciaSuscripcion { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public string PasswordCliente { get; set; }
        public short? NumMesesForSuspension { get; set; }
        public string Urlconsumo { get; set; }
        public int IdequipoCliente { get; set; }
        public int? IdpuntoAcceso { get; set; }
        public bool EnviarFactura { get; set; }
        public int? TipoSuscripcionId { get; set; }

        public virtual Suscriptor CodigoSuscriptorNavigation { get; set; }
        public virtual EquipoEnlaceCliente IdequipoClienteNavigation { get; set; }
        public virtual EstadoSuscripcion IdestadoSuscripcionNavigation { get; set; }
        public virtual PuntoAccesoServicio IdpuntoAccesoNavigation { get; set; }
        public virtual Usuario StrCedulaUsuarioCreadorNavigation { get; set; }
        public virtual SectorCiudad StrIdsectorNavigation { get; set; }
        public virtual Sucursal StrIdsucursalNavigation { get; set; }
        public virtual TipoSuscripcion TipoSuscripcion { get; set; }
        public virtual ICollection<DetalleEmisionServicioCable> DetalleEmisionServicioCables { get; set; }
        public virtual ICollection<ImagenSuscripcion> ImagenSuscripcions { get; set; }
        public virtual ICollection<ServicioSuscripcion> ServicioSuscripcions { get; set; }
        public virtual ICollection<TrackingSuscripcion> TrackingSuscripcions { get; set; }
    }
}
