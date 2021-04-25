using DMS.Application;
using DMS.Application.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DMS.Web
{
    public class ErrorrHandling
    {
        public string GetErrorMessage(Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            string msg = null;
            string Result;
            if (ex is ValidationsException)
            {
                code = HttpStatusCode.Forbidden;

                ValidationsException vex = (ValidationsException)ex;
                msg = vex.ClientMessage;
            };

            if (ex is BusinessException)
            {
                code = HttpStatusCode.Forbidden;
                BusinessException bex = (BusinessException)ex;
                msg = bex.ClientMessage;
            }

            else if (ex is Exception)
            {
                code = HttpStatusCode.InternalServerError;
                msg = "Internal Server Error. Please call customer support.";
            };

            var result = JsonConvert.SerializeObject(new ServerResponse<string> { Result = msg });
            var details = JObject.Parse(result);
            Result = (string)details.First.First;
            return Result;
        }
    }
}
