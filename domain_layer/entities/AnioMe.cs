using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class AnioMe
    {
        public AnioMe()
        {
            EmisionServicioCableIdNavigations = new HashSet<EmisionServicioCable>();
            EmisionServicioCableIds = new HashSet<EmisionServicioCable>();
        }

        public int Idanio { get; set; }
        public int Idmes { get; set; }

        public virtual Anio IdanioNavigation { get; set; }
        public virtual Me IdmesNavigation { get; set; }
        public virtual ICollection<EmisionServicioCable> EmisionServicioCableIdNavigations { get; set; }
        public virtual ICollection<EmisionServicioCable> EmisionServicioCableIds { get; set; }
    }
}
