using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DMS.Application
{
    public class ValidationsException:Exception
    {
        public List<ValidationResult> ValidationData { private set; get; } = new List<ValidationResult>();
        public string ClientMessage { set; get; }

        public ValidationsException()
        {

        }

        public ValidationsException(string clientMessage, string message)
            : base(message)
        {
            this.ClientMessage = clientMessage;
        }

        public ValidationsException(string clientMessage, List<ValidationResult> validationResult)
        {
            this.ValidationData = validationResult;
            this.ClientMessage = clientMessage;
        }


    }
}
