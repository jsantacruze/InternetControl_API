using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class PuntoAccesoServicio
    {
        public PuntoAccesoServicio()
        {
            Suscripcions = new HashSet<Suscripcion>();
        }

        public int IdpuntoAcceso { get; set; }
        public string Descripcion { get; set; }
        public string NumeroSerie { get; set; }
        public string DireccionMac { get; set; }
        public string Marca { get; set; }
        public DateTime? FechaCompra { get; set; }
        public byte[] Imagen { get; set; }
        public string Observaciones { get; set; }
        public string IdtipoEquipo { get; set; }
        public string Idubicacion { get; set; }
        public int? TorreId { get; set; }
        public int? ServidorId { get; set; }
        public int? EquipoMaxClientes { get; set; }
        public string EquipoIp { get; set; }
        public string EquipoSsid { get; set; }
        public string EquipoSsidPassword { get; set; }
        public string EquipoUserAdmin { get; set; }
        public string EquipoUserAdminPassword { get; set; }
        public string EquipoFrecuencia { get; set; }
        public string EquipoModo { get; set; }
        public int? EquipoNumSuscriptores { get; set; }

        public virtual TipoEquipo IdtipoEquipoNavigation { get; set; }
        public virtual UbicacionEnlace IdubicacionNavigation { get; set; }
        public virtual Servidor Servidor { get; set; }
        public virtual TorreDistribucion Torre { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
