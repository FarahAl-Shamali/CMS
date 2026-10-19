using System;
using System.Collections.Generic;
using System.Text;

namespace ContentMS.Core.Exceptions
{
    public class DuplicatedEmailOrPhoneException : Exception
    {
        public DuplicatedEmailOrPhoneException() : base("Duplicated Email Or Phone Exception")
        {

        }
    }
}
