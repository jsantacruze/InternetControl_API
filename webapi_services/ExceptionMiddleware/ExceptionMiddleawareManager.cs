using System;
using System.Net;
using System.Threading.Tasks;
using business_layer.ExceptionManager;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace webapi_services.ExceptionMiddleware
{
    public class ExceptionMiddleawareManager
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleawareManager> _logger;
        public ExceptionMiddleawareManager(RequestDelegate next, ILogger<ExceptionMiddleawareManager> logger){
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context){
            try{
                await _next(context);
            }
            catch(Exception ex){
                await AsyncExceptionManage(context, ex, _logger);

            }
        }

        private async Task AsyncExceptionManage(HttpContext context, Exception ex, ILogger<ExceptionMiddleawareManager> logger){
            object errors = null;
            switch(ex){
                case CustomExceptionHelper ce:
                logger.LogError(ex, "Custom Error");
                errors = ce.Error;
                context.Response.StatusCode = (int)ce.Code;
                break;
                case Exception e:
                    logger.LogError(ex, "Error de Servidor");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var resultados = JsonConvert.SerializeObject(new { errors });
                await context.Response.WriteAsync(resultados);
            }
            

        }
    }
}