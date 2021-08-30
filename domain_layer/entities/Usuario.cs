using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacoras = new HashSet<Bitacora>();
            DetalleEmisionServicioCableIdusuarioCobradorNavigations = new HashSet<DetalleEmisionServicioCable>();
            DetalleEmisionServicioCableIdusuarioCreadorNavigations = new HashSet<DetalleEmisionServicioCable>();
            DetalleEmisionServicioCableIdusuarioSincronizadorNavigations = new HashSet<DetalleEmisionServicioCable>();
            DetalleEmisionServicioCableIduusarioAnuladorNavigations = new HashSet<DetalleEmisionServicioCable>();
            EmisionServicioCables = new HashSet<EmisionServicioCable>();
            Suscripcions = new HashSet<Suscripcion>();
            TrackingSuscripcions = new HashSet<TrackingSuscripcion>();
            UsuarioGrupos = new HashSet<UsuarioGrupo>();
        }

        public string CedulaEmpleado { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool? Activo { get; set; }

        public virtual Empleado CedulaEmpleadoNavigation { get; set; }
        public virtual ICollection<Bitacora> Bitacoras { get; set; }
        public virtual ICollection<DetalleEmisionServicioCable> DetalleEmisionServicioCableIdusuarioCobradorNavigations { get; set; }
        public virtual ICollection<DetalleEmisionServicioCable> DetalleEmisionServicioCableIdusuarioCreadorNavigations { get; set; }
        public virtual ICollection<DetalleEmisionServicioCable> DetalleEmisionServicioCableIdusuarioSincronizadorNavigations { get; set; }
        public virtual ICollection<DetalleEmisionServicioCable> DetalleEmisionServicioCableIduusarioAnuladorNavigations { get; set; }
        public virtual ICollection<EmisionServicioCable> EmisionServicioCables { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
        public virtual ICollection<TrackingSuscripcion> TrackingSuscripcions { get; set; }
        public virtual ICollection<UsuarioGrupo> UsuarioGrupos { get; set; }
    }
}
