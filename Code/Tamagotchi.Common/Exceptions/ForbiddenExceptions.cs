using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Common.Exceptions
{
    public class ForbiddenExceptions : Exception
    {
        public ForbiddenExceptions() : base("Email or Password not invalid")
        {

        }

        public ForbiddenExceptions(Exception e) : base("Email or Password not invalid", e)
        {

        }

        public ForbiddenExceptions(string name, Exception e) : base(name, e)
        {

        }
        public ForbiddenExceptions(string name) : base(name)
        {

        }
    }
}
