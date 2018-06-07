using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Common.Exceptions
{
    public class InvalidSessionExceptions : Exception
    {
        public InvalidSessionExceptions() : base("Not valid session or it has been expired")
        {

        }
    }
}
