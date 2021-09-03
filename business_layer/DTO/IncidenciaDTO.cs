using System;

namespace business_layer.DTO
{
    public class IncidenciaDTO
    {
        //Idtracking
        public long incidencia_id { get; set; }

        //Evento
        public string Evento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string IdusuarioCrea { get; set; }
        public string IdempleadoAsignado { get; set; }
        public DateTime FechaAtencion { get; set; }
        public bool Atendido { get; set; }
        public string Observaciones { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public string StrIdsucursal { get; set; }

        public virtual EmpleadoDTO EmpleadoAsignado { get; set; }
        public virtual UsuarioDTO UsuarioCrea { get; set; }
        public virtual SuscripcionDTO Suscripcion { get; set; }

    }
}