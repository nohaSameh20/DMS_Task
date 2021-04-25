using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application
{
    public class BusinessException:Exception
    {
        public string ClientMessage { set; get; }
        public string BusinessRule { set; get; }
        public BusinessException()
        {

        }
        public BusinessException(string clientMessage, string businessRule)
        {
            this.ClientMessage = clientMessage;
            this.BusinessRule = businessRule;
        }
    }
}
