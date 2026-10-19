using System;
using System.Collections.Generic;
using System.Text;

namespace ContentMS.Core.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(): base("Entity Not Found Exception")
        {

        }
    }
}
