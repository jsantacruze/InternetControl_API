namespace business_layer.DTO
{
    public class SectorCiudadDTO
    {
        public int Idsector { get; set; }
        public string StrIdciudad { get; set; }
        public string DescripcionSector { get; set; }
        public string Referencia { get; set; }

        public CiudadDTO StrIdciudadNavigation { get; set; }

    }
}