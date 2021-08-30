using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data_access;
using domain_layer.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace webapi_services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostServer = CreateHostBuilder(args).Build();
            using(var scope = hostServer.Services.CreateScope()){
                var services = scope.ServiceProvider;
                try{
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var context = services.GetRequiredService<InternetControlContext>();
                    context.Database.Migrate();
                    TestData.InsertUserData(context, userManager).Wait();
                }
                catch(Exception e){
                    var logging = services.GetRequiredService<ILogger<Program>>();
                    logging.LogError(e, "Ocurrió un error en la migración");
                }
            }
            hostServer.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
