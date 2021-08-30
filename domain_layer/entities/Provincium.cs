using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class Provincium
    {
        public Provincium()
        {
            Ciudads = new HashSet<Ciudad>();
        }

        public string StrIdprovincia { get; set; }
        public string StrDescripcionProvincia { get; set; }
        public string StrObservaciones { get; set; }

        public virtual ICollection<Ciudad> Ciudads { get; set; }
    }
}
