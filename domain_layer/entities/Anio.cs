using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Anio
    {
        public Anio()
        {
            AnioMes = new HashSet<AnioMe>();
        }

        public int Idanio { get; set; }
        public string DescripcionAnio { get; set; }
        public bool PeriodoActivo { get; set; }

        public virtual ICollection<AnioMe> AnioMes { get; set; }
    }
}
