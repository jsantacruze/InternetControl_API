using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class TrackingSuscripcion
    {
        public TrackingSuscripcion()
        {
            TrackinSuscripcionImages = new HashSet<TrackinSuscripcionImage>();
        }

        public long Idtracking { get; set; }
        public string Evento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string IdusuarioCrea { get; set; }
        public string IdempleadoAsignado { get; set; }
        public DateTime? FechaAtencion { get; set; }
        public bool Atendido { get; set; }
        public string Observaciones { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public string StrIdsucursal { get; set; }
        public bool RequiereAtencion { get; set; }

        public virtual Empleado IdempleadoAsignadoNavigation { get; set; }
        public virtual Usuario IdusuarioCreaNavigation { get; set; }
        public virtual Suscripcion Suscripcion { get; set; }
        public virtual ICollection<TrackinSuscripcionImage> TrackinSuscripcionImages { get; set; }
    }
}
