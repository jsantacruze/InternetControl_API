using System;
using System.Collections.Generic;

#nullable disable

namespace domain_layer.entities
{
    public partial class TrackinSuscripcionImage
    {
        public long ImageId { get; set; }
        public byte[] ImageValue { get; set; }
        public string ImageDescription { get; set; }
        public long ImageTrackingId { get; set; }

        public virtual TrackingSuscripcion ImageTracking { get; set; }
    }
}
