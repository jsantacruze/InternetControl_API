namespace business_layer.DTO
{
    public class IncidenciaImageDTO
    {
        public long ImageId { get; set; }
        public byte[] ImageValue { get; set; }
        public string ImageDescription { get; set; }
        public long ImageTrackingId { get; set; }
   
    }
}