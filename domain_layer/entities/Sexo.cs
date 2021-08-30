using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Sexo
    {
        public Sexo()
        {
            Empleados = new HashSet<Empleado>();
            Suscriptors = new HashSet<Suscriptor>();
        }

        public string StrId { get; set; }
        public string StrDescripcion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
        public virtual ICollection<Suscriptor> Suscriptors { get; set; }
    }
}
