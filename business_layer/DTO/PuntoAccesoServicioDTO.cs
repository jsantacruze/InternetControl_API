namespace business_layer.DTO
{
    public class PuntoAccesoServicioDTO
    {
        public int IdpuntoAcceso { get; set; }
        public string Descripcion { get; set; }
        public string NumeroSerie { get; set; }
        public string DireccionMac { get; set; }
        public string Marca { get; set; }
        public string Observaciones { get; set; }
    }
}