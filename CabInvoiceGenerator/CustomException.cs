using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CustomException : Exception
    {
          public ExceptionType type;
            public string message;

            public enum ExceptionType
            {
                INVALID_DISTANCE, INVALID_TIME, NULL_RIDES, INVALID_USER_ID
        }
            public CustomException(ExceptionType type, string message) : base(message)
            {
                this.type = type;
            }
        }

}
