using System;
using System.Collections.Generic;
using System.Text;

namespace ContentMS.Core.Exceptions
{
    public class OperationFailedException : Exception
    {
        public OperationFailedException() : base("Operation Failed")
        {

        }
    }
}
