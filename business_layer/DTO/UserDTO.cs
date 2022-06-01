namespace business_layer.DTO
{
    public class UserDTO
    {
        public string NombreCompleto {get; set;}
        public string Token {get; set;}
        public string Email {get; set;}
        public string UserName {get; set;}
        public string Imagen {get; set;}

        public EmpleadoDTO empleado {get; set;}

        public UsuarioDTO usuarioDesktop {get; set;}
    }
}