using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Suscriptor
    {
        public Suscriptor()
        {
            Suscripcions = new HashSet<Suscripcion>();
        }

        public double DblCodigoSuscriptor { get; set; }
        public string StrCedulaRuc { get; set; }
        public string StrNombres { get; set; }
        public string StrApellidos { get; set; }
        public string StrRazonSocial { get; set; }
        public string StrIdciudad { get; set; }
        public string StrDireccion { get; set; }
        public string StrIdsexo { get; set; }
        public string StrTelefono { get; set; }
        public string StrMovil { get; set; }
        public string StrEmail { get; set; }
        public byte[] ImgFoto { get; set; }
        public bool BlnActivo { get; set; }
        public bool BlnPersonaNatural { get; set; }
        public double DblPorcentajeDescuento { get; set; }
        public string StrObservaciones { get; set; }

        public virtual Ciudad StrIdciudadNavigation { get; set; }
        public virtual Sexo StrIdsexoNavigation { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
