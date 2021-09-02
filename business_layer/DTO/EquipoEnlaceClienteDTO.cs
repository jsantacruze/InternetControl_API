namespace business_layer.DTO
{
    public class EquipoEnlaceClienteDTO
    {
         public int Idequipo { get; set; }
        public string Descripcion { get; set; }
        public string NumeroSerie { get; set; }
        public string DireccionMac { get; set; }
        public string Marca { get; set; }
        public DateTime? FechaCompra { get; set; }
        public byte[] Imagen { get; set; }
        public string Observaciones { get; set; }
        public string IdtipoEquipo { get; set; }

        public virtual TipoEquipoDTO IdtipoEquipoNavigation { get; set; }
    }
}