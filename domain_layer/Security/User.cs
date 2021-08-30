using Microsoft.AspNetCore.Identity;

namespace domain_layer.Security
{
    public class User: IdentityUser
    {
        public string NombreCompleto {get; set;}
    }
}