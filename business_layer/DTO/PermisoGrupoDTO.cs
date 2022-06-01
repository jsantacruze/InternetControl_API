namespace business_layer.DTO
{
    public class PermisoGrupoDTO
    {
        public string Idgrupo { get; set; }
        public string Idproceso { get; set; }

        public ProcesoSistemaDTO IdprocesoNavigation { get; set; }
        
    }
}