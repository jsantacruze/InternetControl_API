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

        public string IdtipoEquipo { get; set; }
        public string Idubicacion { get; set; }
        public int? TorreId { get; set; }
        public int? ServidorId { get; set; }
        public int? EquipoMaxClientes { get; set; }
        public string EquipoIp { get; set; }
        public string EquipoSsid { get; set; }
        public string EquipoSsidPassword { get; set; }
        public string EquipoUserAdmin { get; set; }
        public string EquipoUserAdminPassword { get; set; }
        public string EquipoFrecuencia { get; set; }
        public string EquipoModo { get; set; }
        public int? EquipoNumSuscriptores { get; set; }
        public ServidorDTO Servidor { get; set; }
    }
}