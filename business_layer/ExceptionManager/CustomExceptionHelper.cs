using System;
using System.Net;

namespace business_layer.ExceptionManager
{
    public class CustomExceptionHelper : Exception
    {
        public HttpStatusCode Code {get;}
        public object Error {get;}
        public CustomExceptionHelper(HttpStatusCode code, object error = null){
            Code = code;
            Error = error;
        }
    }
}