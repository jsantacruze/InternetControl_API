using System.Collections.Generic;
using domain_layer.Security;

namespace business_layer.IdentitySecurity.Contracts
{
    public interface IJWTGenerator
    {
         string GenerateToken(User user, List<string> roles);
    }
}