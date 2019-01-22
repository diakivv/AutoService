using System;
using System.Collections.Generic;
using System.Text;

namespace AutoService.BLL.Infrastructure
{
    public class InternalServiceException : Exception
    {
        public string Property { get; protected set; }
        public InternalServiceException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
