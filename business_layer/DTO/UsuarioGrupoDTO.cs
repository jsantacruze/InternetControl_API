namespace business_layer.DTO
{
    public class UsuarioGrupoDTO
    {
        public string CedulaUsuario { get; set; }
        public string Idgrupo { get; set; }

        public GrupoUsuarioDTO IdgrupoNavigation { get; set; }
        
    }
}