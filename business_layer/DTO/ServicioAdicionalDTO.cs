namespace business_layer.DTO
{
    public class ServicioAdicionalDTO
    {
        public int IdservicioAdicional { get; set; }
        public string DescripcionServicioAdicional { get; set; }
        public decimal CostoServicioAdicional { get; set; }
        public bool ServicioActivo { get; set; }
        public bool AplicaIva { get; set; }
        public string ObservacionesServicioAdicional { get; set; }
    
    }
}