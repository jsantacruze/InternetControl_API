using System;
namespace business_layer.DTO
{
    public class TrackingSuscripcionDTO
    {
        public long Idtracking { get; set; }
        public string Evento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string IdusuarioCrea { get; set; }
        public string IdempleadoAsignado { get; set; }
        public DateTime FechaAtencion { get; set; }
        public bool Atendido { get; set; }
        public string Observaciones { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public string StrIdsucursal { get; set; }
        public bool RequiereAtencion { get; set; }

        public virtual EmpleadoDTO IdempleadoAsignadoNavigation { get; set; }
        public virtual UsuarioDTO IdusuarioCreaNavigation { get; set; }

    }
}