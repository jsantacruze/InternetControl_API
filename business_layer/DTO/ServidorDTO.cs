namespace business_layer.DTO
{
    public class ServidorDTO
    {
        public int ServidorId { get; set; }
        public string ServidorNombre { get; set; }
        public string ServidorMarca { get; set; }
        public string ServidorIpv4 { get; set; }
        public string ServidorIpv6 { get; set; }
        public string ServidorUser { get; set; }
        public string ServidorPassword { get; set; }
        public string ServidorMacAddress { get; set; }
        public int? ServidorPuerto { get; set; }
        public string ServidorObservaciones { get; set; }

    }
}