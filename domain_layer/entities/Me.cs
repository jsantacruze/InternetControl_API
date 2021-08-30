using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Me
    {
        public Me()
        {
            AnioMes = new HashSet<AnioMe>();
        }

        public int Idmes { get; set; }
        public string DescripcionMes { get; set; }

        public virtual ICollection<AnioMe> AnioMes { get; set; }
    }
}
