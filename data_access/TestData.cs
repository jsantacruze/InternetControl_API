using System.Linq;
using System.Threading.Tasks;
using domain_layer.Security;
using Microsoft.AspNetCore.Identity;

namespace data_access
{
    public class TestData
    {
        public static async Task InsertUserData(InternetControlContext context, UserManager<User> userManager){
            if(!userManager.Users.Any()){
                var user1 = new User{
                    NombreCompleto = "Junior Wachapa Yankur",
                    UserName = "jwachapay",
                    Email = "yankur44@gmail.com"
                };
                await userManager.CreateAsync(user1, "JLeonardoY-");


                var user = new User{
                    NombreCompleto = "Jhovany Santacruz Espinoza",
                    UserName = "jsantacruze",
                    Email = "jsantacruze@hotmail.com"
                };
                await userManager.CreateAsync(user, "Ogriv2012-");
                
                
                var user2 = new User{
                    NombreCompleto = "Tito Guasco Granda",
                    UserName = "tguascog",
                    Email = "titus13.11@gmail.com"
                };
                await userManager.CreateAsync(user2, "TitoGuasco2020-");
            }
        }
    }
}