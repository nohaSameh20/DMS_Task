using DMS.Application;
using DMS.Application.Data;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DMS.Web
{
    public class ErrorHandlingMiddleware
    {
        public class ErrorHandlingMiddleWare
        {
            private readonly RequestDelegate next;
            public ErrorHandlingMiddleWare(RequestDelegate next)
            {
                this.next = next;
            }
            public async Task Invoke(HttpContext context /* other dependencies */)
            {
                try
                {
                    await next(context);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex);
                }

            }

            private static Task HandleExceptionAsync(HttpContext context, Exception ex)
            {
                var code = HttpStatusCode.InternalServerError;

                string msg = null;

                if (ex is ValidationsException)
                {
                    code = HttpStatusCode.Forbidden;

                    ValidationsException vex = (ValidationsException)ex;
                    msg = vex.ClientMessage;
                }

                else if (ex is AuthException)
                {
                    code = HttpStatusCode.Unauthorized;
                    AuthException bex = (AuthException)ex;
                    msg = bex.ClientMessage;
                }

                else if (ex is BusinessException)
                {
                    code = HttpStatusCode.Forbidden;
                    BusinessException bex = (BusinessException)ex;
                    msg = bex.ClientMessage;
                }
                else
                {
                    code = HttpStatusCode.InternalServerError;
                    msg = "Internal Server Error. Please call customer support.";
                }

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;

                var result = JsonConvert.SerializeObject(new ServerResponse<string> { Result = msg });
                return context.Response.WriteAsync(result);
            }
        }
    }
}
