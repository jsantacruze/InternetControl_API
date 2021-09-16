namespace business_layer.DTO
{
    public class ImagenSuscripcionDTO
    {
        public long ImagenId { get; set; }
        public long DblCodigoSuscripcion { get; set; }
        public string StrIdsucursal { get; set; }
        public string ImagenDescripcion { get; set; }
        public byte[] ImagenValue { get; set; }
        public bool ImagenPrincipal { get; set; }
    }
}